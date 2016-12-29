using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface ISntonInboundSourceWorkTaskRepository : IQueryRepository<string, SntonInboundSourceWorkTask>
    {
    }
}