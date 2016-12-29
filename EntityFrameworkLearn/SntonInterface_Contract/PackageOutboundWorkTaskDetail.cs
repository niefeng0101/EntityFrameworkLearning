using System;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{

    public class PackageOutboundWorkTaskDetail : EntityBase<int>
    {
        public int PackageOutboundWorkTaskId { get; set; }
        public int OutOrder { get; set; }
        public string SpoolCode { get; set; }
        public int Status { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
