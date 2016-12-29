using System;
using System.Security.Cryptography.X509Certificates;
using Kengic.Was.Domain.Entity.Common;

namespace Kengic.Was.Domain.Entity.SntonInterface
{
    public interface IPackageInventoryRepository : IRepositoryForOnlyDb<int, PackageInventory>
    {
        PackageInventory GetPackageInventory(string spoolSpec, string steelSpec, string lr);
        //Tuple<bool, string> Create(PackageInventory packageInventory);
        //Tuple<bool, string> Update(PackageInventory packageInventory);
        //Tuple<bool, string> Remove(PackageInventory packageInventory);

    }
}