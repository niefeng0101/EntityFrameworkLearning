using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using Kengic.Was.Domain.Common;
using Kengic.Was.Domain.Entity.SapInterface;

namespace Kengic.Was.Domain.Model.SntonInterface
{
    public class SntonInterfaceModel
        : DbContext, IQueryableUnitOfWork
    {
        static SntonInterfaceModel()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SntonInterfaceModel>());
        }

        public SntonInterfaceModel()
        {
            LogDebug();
            Configuration.ProxyCreationEnabled = false;
            Configuration.UseDatabaseNullSemantics = true;
        }

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        public IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class => Set<TEntity>();

        public void Attach<TEntity>(TEntity item)
            where TEntity : class => Set<TEntity>().Attach(item);

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class => Entry(item).State = EntityState.Modified;

        public void SetDeleted<TEntity>(TEntity item) where TEntity : class => Entry(item).State = EntityState.Deleted;

        public void SetDetached<TEntity>(TEntity item) where TEntity : class
            => Entry(item).State = EntityState.Detached;

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class => Entry(original).CurrentValues.SetValues(current);

        public void Commit() => SaveChanges();

        public void CommitAndRefreshChanges()
        {
            bool saveFailed;

            do
            {
                try
                {
                    SaveChanges();

                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                        .ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValues()));
                }
            } while (saveFailed);
        }

        public void RollbackChanges() => ChangeTracker.Entries()
            .ToList()
            .ForEach(entry => entry.State = EntityState.Unchanged);

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
            => Database.SqlQuery<TEntity>(sqlQuery, parameters);

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
            => Database.ExecuteSqlCommand(sqlCommand, parameters);

        public void SetPropertiesModified<TEntity>(TEntity item, List<string> properties) where TEntity : class
        {
            var entry = Entry(item);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        [Conditional("DEBUG")]
        // ReSharper disable once UnusedMember.Local
        private void LogDebug() => Database.Log = r => Debug.WriteLine(r);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(nameof(SntonInterfaceModel).Replace("Model", string.Empty).ToUpper());
            modelBuilder.Entity<SapSourceTask>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}