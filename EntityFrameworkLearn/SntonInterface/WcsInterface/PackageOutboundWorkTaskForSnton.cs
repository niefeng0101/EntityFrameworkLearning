using System;
using Kengic.Was.Domain.Entity.WorkTask.Outbounds;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class PackageOutboundTaskForSnton : OutboundProcessWorkTask
    {
        public string SpoolSpec { get; set; }
        public string SteelSpec { get; set; }
        public int OutNumber { get; set; }
        public SntonWorkTaskStatus SntonWorkTaskStatus { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
