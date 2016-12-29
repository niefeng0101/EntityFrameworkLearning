using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Common
{
    public class DatabaseInterfaceForOnlyDb<TKey, TEntity> : IRepositoryForOnlyDb<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
        private IQueryableUnitOfWork _unitOfWork;

        public DatabaseInterfaceForOnlyDb(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _unitOfWork = unitOfWork;

            LogName = GetType().Name;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public string LogName { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual Tuple<bool, string> Create(TEntity item)
        {
            string messageCode;
            if ((item == null) || EqualityComparer<TKey>.Default.Equals(item.Id, default(TKey)))
            {
                return new Tuple<bool, string>(false, "StaticParameterForMessage.ObjectIsNotExist");
            }

            try
            {
                //item.CreateTime = DateTime.Now;
                GetSet().Add(item); // add new item in this set
                UnitOfWork.Commit();

                messageCode = "StaticParameterForMessage.CreateSuccess";
                //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
                return new Tuple<bool, string>(true, messageCode);
            }
            catch (Exception ex)
            {
                messageCode = "StaticParameterForMessage.CreateException";
                //LogRepository.WriteExceptionLog(LogName, messageCode, item.Id + ":" + ex);
                return new Tuple<bool, string>(false, messageCode);
            }
        }

        public virtual Tuple<bool, string> Update(TEntity item)
        {
            string messageCode;
            if ((item == null) || EqualityComparer<TKey>.Default.Equals(item.Id, default(TKey)))
            {
                return new Tuple<bool, string>(false, "StaticParameterForMessage.ObjectIsNotExist");
            }

            try
            {
                //item.UpdateTime = DateTime.Now;
                var persisted = TryGetValue(item.Id);
                _unitOfWork.ApplyCurrentValues(persisted, item);
                UnitOfWork.Commit();

                messageCode = "StaticParameterForMessage.UpdateSuccess";
                //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
                return new Tuple<bool, string>(true, messageCode);
            }
            catch (Exception ex)
            {
                messageCode = "StaticParameterForMessage.UpdateException";
                //LogRepository.WriteExceptionLog(LogName, messageCode, item.Id + ":" + ex);
                return new Tuple<bool, string>(false, messageCode);
            }
        }

        public virtual Tuple<bool, string> Remove(TEntity item)
        {
            string messageCode;
            if ((item == null) || EqualityComparer<TKey>.Default.Equals(item.Id, default(TKey)))
            {
                return new Tuple<bool, string>(false, "StaticParameterForMessage.ObjectIsNotExist");
            }

            try
            {
                var persisted = TryGetValue(item.Id);
                _unitOfWork.Attach(persisted);
                //set as "removed"
                GetSet().Remove(persisted);
                UnitOfWork.Commit();

                messageCode = "StaticParameterForMessage.RemoveSuccess";
                //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
                return new Tuple<bool, string>(true, messageCode);
            }
            catch (Exception ex)
            {
                messageCode = "StaticParameterForMessage.RemoveException";
                //LogRepository.WriteExceptionLog(LogName, messageCode, item.Id + ":" + ex);
                return new Tuple<bool, string>(false, messageCode);
            }
        }

        public virtual void TrackItem(TEntity item) => _unitOfWork.Attach(item);

        public virtual TEntity TryGetValue(TKey id)
            => !EqualityComparer<TKey>.Default.Equals(id, default(TKey)) ? GetSet().Find(id) : null;

        public virtual IQueryable<TEntity> GetAll() => GetSet();

        public virtual IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
            => GetSet().Where(filter);

        public virtual IEnumerable<TEntity> GetPaged<TKProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, TKProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                    .Skip(pageCount*pageIndex)
                    .Take(pageCount);
            }
            return set.OrderByDescending(orderByExpression)
                .Skip(pageCount*pageIndex)
                .Take(pageCount);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (_unitOfWork == null)
            {
                return;
            }
            _unitOfWork.Dispose();
            _unitOfWork = null;
        }

        protected IDbSet<TEntity> GetSet() => _unitOfWork.CreateSet<TEntity>();
    }
}