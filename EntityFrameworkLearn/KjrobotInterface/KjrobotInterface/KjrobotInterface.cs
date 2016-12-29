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
    public class KjrobotInterface : DbContext
    {
        static KjrobotInterface()
        {
            Database.SetInitializer<KjrobotInterface>(null);
        }

        public DbSet<PackageInventory> PackageInventories { get; set; }

        public DbSet<PackageOutboundWorkTask> PackageOutboundWorkTasks { get; set; }
        public DbSet<PackageOutboundWorkTaskDetail> PackageOutboundWorkTaskDeatails { get; set; }

        // ReSharper disable once EmptyConstructor
        public KjrobotInterface()
            : base("name=KjrobotInterface")
        {
            //LogDebug();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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