using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Common
{
    /// <summary>
    ///     Repository base class
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The type of underlying entity in this repository
    /// </typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class RepositoryForOnlyDb<TKey, TEntity> : IRepositoryForOnlyDb<TKey, TEntity>
        where TEntity : EntityForTime<TKey>
    {
        private readonly IQueryableUnitOfWork _unitOfWork;

        public RepositoryForOnlyDb(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _unitOfWork = unitOfWork;

            LogName = GetType().Name;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public string LogName { get; set; }

        public virtual Tuple<bool, string> Create(TEntity item)
        {
            string messageCode;
            if ((item == null) || EqualityComparer<TKey>.Default.Equals(item.Id, default(TKey)))
            {
                return new Tuple<bool, string>(false, "StaticParameterForMessage.ObjectIsNotExist");
            }

            try
            {
                item.CreateTime = DateTime.Now;
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
                item.UpdateTime = DateTime.Now;
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            _unitOfWork?.Dispose();
        }

        protected IDbSet<TEntity> GetSet() => _unitOfWork.CreateSet<TEntity>();
    }
}