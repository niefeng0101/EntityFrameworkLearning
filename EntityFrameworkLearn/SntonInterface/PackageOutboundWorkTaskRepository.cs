using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Kengic.Was.Domain.Common;
using Kengic.Was.Domain.Entity.SntonInterface;
using Kengic.Was.Domain.Model.KjrobotInterfaceModel;

namespace Kengic.Was.Domain.SntonInterface
{
    public class PackageOutboundWorkTaskRepository : DatabaseInterfaceForOnlyDb<int, PackageOutboundWorkTask>
        , IPackageOutboundWorkTaskRepository
    {
        readonly KjrobotInterface _context = new KjrobotInterface();

        public List<PackageOutboundWorkTask> GetWithStatus() => GetAll().Where(r => r.Status == SntonWorkTaskStatus.Create).ToList();

        public PackageOutboundWorkTask GetPackageOutboundWorkTask(string spoolSpec, string steelSpec, string lr)
        {
            var outboundTaskList = GetAll().Where(e => e.SpoolSpec == spoolSpec
                                         && e.SteelSpec == steelSpec
                                         && e.Lr == lr).ToList();

            return outboundTaskList.Count > 0 ? outboundTaskList[0] : null;
        }

        public PackageOutboundWorkTask GetWithAll(int id)
        => GetAll().FirstOrDefault(r => r.Id == id);

        //public Tuple<bool, string> Create(PackageOutboundWorkTask packageOutboundTask)
        //{
        //    try
        //    {
        //        _context.PackageOutboundWorkTasks.Add(packageOutboundTask);
        //        _context.SaveChanges();

        //        //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());
        //        return new Tuple<bool, string>(true, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Tuple<bool, string>(false, "");
        //    }
        //}

        //public Tuple<bool, string> Update(PackageOutboundWorkTask packageOutboundTask)
        //{
        //    try
        //    {
        //        _context.PackageOutboundWorkTasks.AddOrUpdate(packageOutboundTask);
        //        _context.SaveChanges();

        //        //LogRepository.WriteInfomationLog(LogName, messageCode, item.Id.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return new Tuple<bool, string>(true, "");
        //}

        //public Tuple<bool, string> Remove(PackageOutboundWorkTask packageOutboundTask)
        //{
        //    try
        //    {
        //        _context.PackageOutboundWorkTasks.Remove(packageOutboundTask);
        //        _context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return new Tuple<bool, string>(true, "");
        //}

        public PackageOutboundWorkTaskRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}