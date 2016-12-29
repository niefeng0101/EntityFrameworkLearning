using System;
using System.Collections.Generic;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface IPackageOutboundWorkTaskRepository
    {
        List<PackageOutboundWorkTask> GetWithStatus();
        PackageOutboundWorkTask GetPackageOutboundWorkTask(string spoolSpec, string steelSpec, string lr);
        PackageOutboundWorkTask GetWithAll(int id);
        Tuple<bool, string> Create(PackageOutboundWorkTask packageOutboundTask);
        Tuple<bool, string> Update(PackageOutboundWorkTask packageOutboundTask);
        Tuple<bool, string> Remove(PackageOutboundWorkTask packageOutboundTask);
    }
}