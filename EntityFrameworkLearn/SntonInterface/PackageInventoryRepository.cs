using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Kengic.Was.Domain.Common;
using Kengic.Was.Domain.Entity.SntonInterface;
using Kengic.Was.Domain.Model.KjrobotInterfaceModel;

namespace Kengic.Was.Domain.SntonInterface
{
    public class PackageInventoryRepository : KjrobotInterface//DatabaseInterfaceForOnlyDb<int, PackageInventory>, IPackageInventoryRepository
    {
        //public PackageInventoryRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //readonly KjrobotInterface _context = new KjrobotInterface();
        //public PackageInventory GetPackageInventory(string spoolSpec, string steelSpec, string lr)
        //{
        //    //var inventoryList = _context.PackageInventories
        //    //    .Where(e => (e.SpoolSpec == spoolSpec)
        //    //        && (e.SteelSpec == steelSpec)
        //    //        && (e.LR == lr)).ToList();

        //    //return inventoryList.Count >= 1 ? inventoryList[0] : null;

        //    //var inventoryList = GetAll().Where(e => (e.SpoolSpec == spoolSpec)
        //    //        && (e.SteelSpec == steelSpec)
        //    //        && (e.LR == lr)).ToList();
        //    //return inventoryList.Count >= 1 ? inventoryList[0] : null;
        //}

        //public Tuple<bool, string> Create(PackageInventory packageInventory)
        //{
        //    string messageCode;
        //    try
        //    {
        //        _context.PackageInventories.AddOrUpdate(packageInventory);
        //        _context.SaveChanges();

        //        messageCode = "";
        //        return new Tuple<bool, string>(true, messageCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        messageCode = "";
        //        return new Tuple<bool, string>(false, messageCode);
        //    }
        //}

        //public Tuple<bool, string> Update(PackageInventory packageInventory)
        //{
        //    try
        //    {
        //        _context.PackageInventories.AddOrUpdate(packageInventory);
        //        _context.SaveChanges();

        //        var messageCode = "";
        //        //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
        //        return new Tuple<bool, string>(true, messageCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        var messageCode = "StaticParameterForMessage.CreateException";
        //        return new Tuple<bool, string>(false, messageCode);
        //    }
        //}

        //public Tuple<bool, string> Remove(PackageInventory packageInventory)
        //{
        //    try
        //    {
        //        _context.PackageInventories.Remove(packageInventory);
        //        _context.SaveChanges();

        //        var messageCode = "StaticParameterForMessage.CreateSuccess";
        //        //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
        //        return new Tuple<bool, string>(true, messageCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        var messageCode = "StaticParameterForMessage.CreateException";
        //        return new Tuple<bool, string>(false, messageCode);
        //    }
        //}

    }
}