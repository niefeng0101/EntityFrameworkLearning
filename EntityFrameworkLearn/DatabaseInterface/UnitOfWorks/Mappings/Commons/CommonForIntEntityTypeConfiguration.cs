using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Model.SntonInterface.UnitOfWorks.Mappings.Commons
{
    internal class CommonForIntEntityTypeConfiguration<TEntity>
        : EntityTypeConfiguration<TEntity> where TEntity : EntityBase<int>
    {
        public CommonForIntEntityTypeConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}