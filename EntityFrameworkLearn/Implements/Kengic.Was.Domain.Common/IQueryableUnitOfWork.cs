﻿using System.Collections.Generic;
using System.Data.Entity;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Common
{
    public interface IQueryableUnitOfWork
        : IUnitOfWork, ISql
    {
        bool AutoDetectChangesEnabled { get; set; }
        void SetPropertiesModified<TEntity>(TEntity item, List<string> propertyEntries) where TEntity : class;

        /// <summary>
        ///     Returns a <see cref="IDbSet{TEntity}" /> instance for access to entities of
        ///     the given type in the context, the ObjectStateManager, and the
        ///     underlying store.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>
        /// </returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        ///     <see cref="Attach{TEntity}" /> this <paramref name="item" /> into
        ///     "ObjectStateManager"
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="item">The item</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        ///     Set object as modified
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="item">The entity item to set as modifed</param>
        void SetModified<TEntity>(TEntity item) where TEntity : class;

        void SetDetached<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        ///     Apply <paramref name="current" /> values in
        ///     <paramref name="original" />
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}