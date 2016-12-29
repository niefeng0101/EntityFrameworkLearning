using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public class PackageInventory : EntityBase<int>
    {
        public string SpoolSpec { get; set; }
        public string SteelSpec { get; set; }
        public string LR { get; set; }
        public int AgingTime { get; set; }
        public int AllNumber { get; set; }
        public int NowNumber { get; set; }
    }
}
