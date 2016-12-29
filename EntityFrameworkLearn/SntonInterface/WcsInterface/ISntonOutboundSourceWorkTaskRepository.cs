using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface ISntonOutboundSourceWorkTaskRepository : IQueryRepository<string, SntonInboundSourceWorkTask>
    {
    }
}