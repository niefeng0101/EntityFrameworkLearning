using System;
using System.Collections.Generic;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class PackageOutboundWorkTask : EntityBase<int>
    {
        // public int Id { get; set; }
        public string SpoolSpec { get; set; }
        public string SteelSpec { get; set; }
        public string Lr { get; set; }
        public int OutNumber { get; set; }
        public SntonWorkTaskStatus Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<PackageOutboundWorkTaskDetail> PackageOutboundWorkTaskDetails { get; set; }
    }
}
