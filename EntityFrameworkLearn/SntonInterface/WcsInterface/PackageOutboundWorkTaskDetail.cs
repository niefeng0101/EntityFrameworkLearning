using System;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class PackageOutboundWorkTaskDetail : EntityBase<int>
    {
        public string PackageOutboundWorkTaskId { get; set; }
        public string OutID { get; set; }
        public int SpoolCode { get; set; }
        public int Status{ get; set; }
        public DateTime? EndTime { get; set; }
        public PackageOutboundWorkTask PackageOutboundWorkTask { get; set; }
    }
}
