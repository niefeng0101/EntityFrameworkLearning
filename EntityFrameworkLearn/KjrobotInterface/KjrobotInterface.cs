using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using Kengic.Was.Domain.Common;
using Kengic.Was.Domain.Entity.SntonInterface;


namespace Kengic.Was.Domain.Model.KjrobotInterfaceModel
{
    public class KjrobotInterface : DbContext, IQueryableUnitOfWork
    {
        // ReSharper disable once EmptyConstructor
        public KjrobotInterface()
            : base("name=KjrobotInterface")
        {
            Configuration.ProxyCreationEnabled = false;
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

        public void SetDetached<TEntity>(TEntity item) where TEntity : class => Entry(item).State = EntityState.Detached;

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
            Database.SetInitializer<KjrobotInterface>(null);

            modelBuilder.Entity<PackageInventory>().ToTable("tb_inventory")
                .HasKey(e => e.Id)
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PackageOutboundWorkTask>().ToTable("tb_outstock")
                 .HasKey(e => e.Id)
                 .Property(t => t.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PackageOutboundWorkTaskDetail>().ToTable("tb_outdetail")
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}