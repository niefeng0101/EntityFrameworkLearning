using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.DatabaseInterface.UnitOfWork.Mapping.Common
{
    internal class CommonEntityTypeConfiguration<TEntity>
        : EntityTypeConfiguration<TEntity> where TEntity : EntityBase<string>
    {
        public CommonEntityTypeConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}