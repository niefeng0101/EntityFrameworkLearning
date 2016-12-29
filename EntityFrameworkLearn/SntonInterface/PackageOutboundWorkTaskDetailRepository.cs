using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Kengic.Was.Domain.Common;
using Kengic.Was.Domain.Entity.SntonInterface;
using Kengic.Was.Domain.Model.KjrobotInterfaceModel;

namespace Kengic.Was.Domain.SntonInterface
{
    public class PackageOutboundWorkTaskDetailRepository : DatabaseInterfaceForOnlyDb<int, PackageOutboundWorkTaskDetail>
        , IPackageOutboundWorkTaskDetailRepository
    {
        //readonly KjrobotInterface _context = new KjrobotInterface();

        public int GetMaximalOutOrder(int packageOutboundWorkTaskId)
        {
            var outOrderList = GetAll()
                .Where(e => e.PackageOutboundWorkTaskId == packageOutboundWorkTaskId).ToList();
            if (outOrderList.Any())
            {
                return outOrderList.Max(e => e.OutOrder);
            }
            return -1;
        }

    //    public Tuple<bool, string> Create(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail)
    //    {
    //        try
    //        {
    //            _context.PackageOutboundWorkTaskDeatails.Add(packageOutboundWorkTaskDetail);
    //            _context.SaveChanges();

    //            var messageCode = "StaticParameterForMessage.CreateSuccess";
    //            //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
    //            return new Tuple<bool, string>(true, messageCode);
    //        }
    //        catch (Exception ex)
    //        {
    //            var messageCode = "StaticParameterForMessage.CreateException";
    //            return new Tuple<bool, string>(false, messageCode);
    //        }
    //    }

    //    public Tuple<bool, string> Update(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail)
    //    {
    //        try
    //        {
    //            _context.PackageOutboundWorkTaskDeatails.AddOrUpdate(packageOutboundWorkTaskDetail);
    //            _context.SaveChanges();

    //            var messageCode = "StaticParameterForMessage.CreateSuccess";
    //            //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
    //            return new Tuple<bool, string>(true, messageCode);
    //        }
    //        catch (Exception ex)
    //        {
    //            var messageCode = "StaticParameterForMessage.CreateException";
    //            return new Tuple<bool, string>(false, messageCode);
    //        }
    //    }

    //    public Tuple<bool, string> Remove(PackageOutboundWorkTaskDetail packageOutboundWorkTaskDetail)
    //    {
    //        try
    //{
    //            _context.PackageOutboundWorkTaskDeatails.Remove(packageOutboundWorkTaskDetail);
    //            _context.SaveChanges();

    //            var messageCode = "StaticParameterForMessage.CreateSuccess";
    //            //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
    //            return new Tuple<bool, string>(true, messageCode);
    //        }
    //        catch (Exception ex)
    //    {
    //            var messageCode = "StaticParameterForMessage.CreateException";
    //            return new Tuple<bool, string>(false, messageCode);
    //        }
    //    }

        public PackageOutboundWorkTaskDetailRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}