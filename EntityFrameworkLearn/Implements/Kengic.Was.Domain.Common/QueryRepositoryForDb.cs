using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Common
{
    /// <summary>
    ///     only for <see langword="operator" />
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryRepositoryForDb<TKey, TEntity> : IQueryRepository<TKey, TEntity>
        where TEntity : Entity<TKey>
    {
        private readonly IQueryableUnitOfWork _unitOfWork;

        public QueryRepositoryForDb(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public virtual TEntity TryGetValue(TKey id)
            => !EqualityComparer<TKey>.Default.Equals(id, default(TKey)) ? GetSet().Find(id) : null;

        public virtual IQueryable<TEntity> GetAll() => GetSet();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void TrackItem(TEntity item) => _unitOfWork.Attach(item);

        protected IDbSet<TEntity> GetSet() => _unitOfWork.CreateSet<TEntity>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            _unitOfWork?.Dispose();
        }
    }
}