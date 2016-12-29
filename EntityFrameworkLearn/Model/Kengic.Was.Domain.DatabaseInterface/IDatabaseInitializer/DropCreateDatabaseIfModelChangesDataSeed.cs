//using System;
//using System.Data.Entity;
//using Kengic.Was.Domain.Entity.WcsInterface;

//namespace Kengic.Was.Domain.DatabaseInterface.IDatabaseInitializer
//{
//    public class DropCreateDatabaseIfModelChangesDataSeed : DropCreateDatabaseIfModelChanges<DatabaseInterface>
//    {
//        protected override void Seed(DatabaseInterface context) => InitializeWcsInterfaceSourceWorkTaskTemplate(context);

//        private static void InitializeWcsInterfaceSourceWorkTaskTemplate(DbContext context)
//        {
//            var wcsInterfaceSourceWorkTask = new WcsInterfaceSourceWorkTask
//            {
//                Id = "AutoCreateWcsTask",
//                Code = "AutoCreateWcsTask",
//                Name = "Auto Create WCS Task",
//                ContainerCode = "1",
//                Description = "Create Wcs simulation task automatically",
//                CreateBy = "System",
//                CreateTime = DateTime.Now
//            };
//            context.Set<WcsInterfaceSourceWorkTask>().Add(wcsInterfaceSourceWorkTask);
//        }
//    }
//}