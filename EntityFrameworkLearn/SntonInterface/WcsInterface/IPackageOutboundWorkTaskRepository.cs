using System.Collections.Generic;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface IPackageOutboundWorkTaskRepository : IRepositoryForOnlyDb<int, PackageOutboundWorkTask>
    {
        List<PackageOutboundWorkTask> GetWithStatus();
        PackageOutboundWorkTask GetPackageOutboundWorkTask(string spoolSpec, string steelSpec, string lr);
        PackageOutboundWorkTask GetWithAll(int id);
    }
}