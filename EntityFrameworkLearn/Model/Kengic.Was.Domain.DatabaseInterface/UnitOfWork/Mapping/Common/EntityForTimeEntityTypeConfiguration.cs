using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.DatabaseInterface.UnitOfWork.Mapping.Common
{
    internal class EntityForTimeEntityTypeConfiguration<TEntity>
        : CommonEntityTypeConfiguration<TEntity> where TEntity : EntityForTime<string>
    {
        public EntityForTimeEntityTypeConfiguration()
        {
            Property(t => t.CreateBy).HasMaxLength(256);
            Property(t => t.UpdateBy).HasMaxLength(256);
        }
    }
}