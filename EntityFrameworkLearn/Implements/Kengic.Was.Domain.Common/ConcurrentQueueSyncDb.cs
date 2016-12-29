using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Common
{
    public class ConcurrentQueueSyncDb<TKey, TValue> : IDisposable where TValue : Entity<TKey>, new()
    {
        private readonly Expression<Func<TValue, bool>> _filterExpression;
        private readonly Func<TValue, bool> _filterFunc;
        private readonly IQueryableUnitOfWork _unitOfWork;

        private Lazy<ConcurrentDictionary<TKey, TValue>> _cDictionary;

        public ConcurrentQueueSyncDb(IQueryableUnitOfWork unitOfWork, Expression<Func<TValue, bool>> filter = null)
        {
            _unitOfWork = unitOfWork;
            _filterExpression = filter;
            if (_filterExpression != null)
            {
                _filterFunc = _filterExpression.Compile();
            }
            Load();
        }

        public ICollection<TKey> Keys => _cDictionary.Value.Keys;

        public ICollection<TValue> Values => _cDictionary.Value.Values;

        public IDbSet<TValue> DbSet => _unitOfWork.CreateSet<TValue>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            //if (!disposing)
            //{
            //    return;
            //}
            //if (_unitOfWork == null)
            //{
            //    return;
            //}
            //_unitOfWork.Dispose();
            //_unitOfWork = null;
        }

        public void Load() => _cDictionary = new Lazy<ConcurrentDictionary<TKey, TValue>>(GetDataDictionary);

        private ConcurrentDictionary<TKey, TValue> GetDataDictionary()
        {
            var entitySet = _unitOfWork.CreateSet<TValue>();
            var dbDictionary = _filterExpression == null
                ? entitySet.ToDictionary(r => r.Id)
                : entitySet.Where(_filterExpression).ToDictionary(r => r.Id);
            return new ConcurrentDictionary<TKey, TValue>(dbDictionary);
        }

        public bool AddOrUpdate(TValue addValue)
        {
            var toFilterValues = true;
            if (_filterFunc != null)
            {
                toFilterValues = _filterFunc(addValue);
            }

            try
            {
                _unitOfWork.AutoDetectChangesEnabled = false;
                _unitOfWork.CreateSet<TValue>().AddOrUpdate(r => r.Id, addValue);
                _unitOfWork.Commit();
                _unitOfWork.AutoDetectChangesEnabled = true;
                if (!toFilterValues)
                {
                    _unitOfWork.SetDetached(addValue);
                }
                try
                {
                    _cDictionary.Value.AddOrUpdate(addValue.Id, addValue, (k, v) => addValue);
                    if (!toFilterValues)
                    {
                        TValue value;
                        _cDictionary.Value.TryRemove(addValue.Id, out value);
                    }
                }
                catch
                {
                    Load();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     以实体的Id为Key 操作成功失败只以数据库操作为准,内存操作失败则重新加载数据库到内存,以保持一致
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// </returns>
        public bool TryAdd(TValue value)
        {
            _unitOfWork.AutoDetectChangesEnabled = false;
            var newValue = _unitOfWork.CreateSet<TValue>().Add(value);
            _unitOfWork.Commit();
            _unitOfWork.AutoDetectChangesEnabled = true;


            try
            {
                var result = _cDictionary.Value.TryAdd(newValue.Id, newValue);
                if (!result)
                {
                    Load();
                }
            }
            catch
            {
                Load();
            }
            return true;
        }

        /// <summary>
        ///     先去内存查找,查不到再去数据库查
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// </returns>
        public TValue TryGetValue(TKey key)
        {
            TValue result;
            if (_cDictionary.Value.TryGetValue(key, out result))
            {
                return result;
            }

            result = _unitOfWork.CreateSet<TValue>().Find(key);
            if (result != null)
            {
                Load();
            }
            return result;
        }

        public bool TryRemove(TKey key)
        {
            var value = _unitOfWork.CreateSet<TValue>().Find(key);
            _unitOfWork.CreateSet<TValue>().Remove(value);
            _unitOfWork.Commit();


            try
            {
                TValue outValue;
                return _cDictionary.Value.TryRemove(key, out outValue);
            }
            catch
            {
                Load();
            }
            return true;
        }

        public bool TryUpdate(TValue newValue, List<string> properties = null)
        {
            var toFilterValues = true;
            if (_filterFunc != null)
            {
                toFilterValues = _filterFunc(newValue);
            }

            if (properties == null)
            {
                var persisted = TryGetValue(newValue.Id);
                _unitOfWork.ApplyCurrentValues(persisted, newValue);
            }
            else
            {
                _unitOfWork.SetPropertiesModified(newValue, properties);
            }

            _unitOfWork.Commit();
            if (!toFilterValues)
            {
                _unitOfWork.SetDetached(newValue);
            }

            try
            {
                var result = _cDictionary.Value.TryUpdate(newValue.Id, newValue, newValue);
                if (!result)
                {
                    Load();
                }
                else
                {
                    if (!toFilterValues)
                    {
                        TValue value;
                        _cDictionary.Value.TryRemove(newValue.Id, out value);
                    }
                }
            }
            catch
            {
                Load();
            }
            return true;
        }

        public bool IsExist(TKey key) => _cDictionary.Value.ContainsKey(key);
    }
}