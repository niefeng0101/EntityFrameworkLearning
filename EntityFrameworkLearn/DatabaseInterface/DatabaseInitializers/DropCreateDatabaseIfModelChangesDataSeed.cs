using System;
using System.Data.Entity;
using Kengic.Was.Domain.Model.SapInterface;

namespace Kengic.Was.Domain.Model.SntonInterface.DatabaseInitializers
{
    public class DropCreateDatabaseIfModelChangesDataSeed : DropCreateDatabaseIfModelChanges<SapInterfaceModel>
    {
        protected override void Seed(SapInterfaceModel context) => InitializeWcsInterfaceSourceWorkTaskTemplate(context);

        private static void InitializeWcsInterfaceSourceWorkTaskTemplate(DbContext context)
        {
            //var wcsInterfaceSourceWorkTask = new WcsInterfaceSourceWorkTask
            //{
            //    Id = "AutoCreateWcsTask",
            //    Code = "AutoCreateWcsTask",
            //    Name = "Auto Create WCS Task",
            //    ContainerCode = "1",
            //    Description = "Create Wcs simulation task automatically",
            //    CreateBy = "System",
            //    CreateTime = DateTime.Now
            //};
            //context.Set<WcsInterfaceSourceWorkTask>().Add(wcsInterfaceSourceWorkTask);
        }
    }
}