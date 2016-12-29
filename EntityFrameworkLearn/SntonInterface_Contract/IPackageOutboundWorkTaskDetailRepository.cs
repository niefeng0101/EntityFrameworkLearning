using System;
using System.Security.Cryptography.X509Certificates;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface IPackageOutboundWorkTaskDetailRepository
    {
        int GetMaximalOutOrder(int packageOutboundWorkTaskId);
        //Tuple<bool, string> Create(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail);
        //Tuple<bool, string> Update(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail);
        //Tuple<bool, string> Remove(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail);
    }
}