using System;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class SpoolSpecInfo
    {
        public string EndWrkDate { get; set; }
        public string Const { get; set; }
        public string Cname { get; set; }
        public Decimal WeldCount { get; set; }
        public string LR { get; set; }
        public string MachCode { get; set; }
        public string SampleYN { get; set; }
        public string ProdCode { get; set; }/*품목코드*/
        public decimal Length { get; set; }/*길이*/
        public string EndUser { get; set; }/*작업자*/
        public string ConstCode { get; set; }/*구조코드*/
        public string SampleNo { get; set; }
    }
}
