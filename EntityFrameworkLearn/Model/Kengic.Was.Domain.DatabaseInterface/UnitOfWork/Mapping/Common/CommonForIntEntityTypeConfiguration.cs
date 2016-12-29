using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.DatabaseInterface.UnitOfWork.Mapping.Common
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