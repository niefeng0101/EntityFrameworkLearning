using System;
using System.Collections.Generic;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class SpoolSpecInfo : EntityBase<int>
    {
        public DateTime? EndWrkDate { get; set; }
        public string Const { get; set; }
        public string Cname { get; set; }
        public int WeldCount { get; set; }
        public string LR { get; set; }
        public string MachCode { get; set; }
        public string SampleYN { get; set; }
    }
}
