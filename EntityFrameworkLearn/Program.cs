using System;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using Kengic.Was.Domain.Entity.SntonInterface;
using Kengic.Was.Domain.Model.KjrobotInterfaceModel;
using Kengic.Was.Domain.Model.SntonInterface;
using Kengic.Was.Domain.SntonInterface;
using Microsoft.Practices.ServiceLocation;

namespace EntityFrameworkLearn
{
    class Program
    {
        //static readonly SntonContext Db = new SntonContext();
        //static readonly KjrobotInterface Db =new KjrobotInterface();
        //static readonly SntonMesInterface Db1=new SntonMesInterface();
        private static void Main(string[] args)
        {
            Console.WriteLine("数据库初始化完成");
            var scannerCodes = Console.ReadLine();
            var scanCode1 = scannerCodes.Substring(0, 10).Trim();
            var scanCode2 = scannerCodes.Substring(10, 10).Trim();

            //var inventories = Db.PackageInventories.Where(e => e.Id == 1).ToList();
            ////var inventories = db.Database.SqlQuery<PackageInventory>(@"select * from dbo.tb_inventory 
            ////         where spoolspec='1' and lr='1' and Steelspec='1'").ToList();
            ////         var inventories = db.PackageInventories.SqlQuery(@"select * from dbo.tb_inventory 
            ////         where spoolspec='1'
            ////and lr='1'
            ////and Steelspec='1'").ToList();

            //if (inventories.Count > 0)
            //{
            //    PackageInventory p = inventories[0];
            //    //p.AllNumber++;
            //    Console.WriteLine(p.AllNumber);
            //    Console.WriteLine(p.SteelSpec);
            //    //Db.PackageInventories.AddOrUpdate(p);
            //    //Db.SaveChanges();

            //}

            //var v = new PackageInventory
            //{
            //    ID = 5,
            //    SpoolSpec = "1",
            //    SteelSpec = "2",
            //    LR = "1",
            //    AgingTime = 1,
            //    AllNumber = 5,
            //    NowNumber = 3
            //};
            //Db.PackageInventories.Add(v);
            //Db.SaveChanges();

            //var v = new PackageOutboundWorkTask()
            //{
            //    PackageOutboundWorkTaskID=5,
            //    OutNumber = 2,
            //    SpoolSpec = "1",
            //    SteelSpec = "1",
            //    Status = 0
            //};
            //Db.PackageOutboundWorkTasks.Add(v);
            //Db.SaveChanges();


            //var work = Db.PackageOutboundWorkTasks.Where(e => e.Status == 0).ToList();

            //var work = Db.PackageOutboundWorkTasks.FirstOrDefault(e => e.SpoolSpec == "1"
            //                                                           && e.SteelSpec == "1"
            //                                                           && e.Status == 0);

            //Console.WriteLine(work.ToString());
            //var v = new PackageOutboundWorkTaskDetail()
            //{
            //    //Id = work[0].Id,
            //    PackageOutboundWorkTaskId = work[0].Id,
            //    SpoolCode = "123321",
            //    OutOrder = 1,
            //    EndTime = DateTime.Now
            //};

            //Db.PackageOutboundWorkTaskDeatails.AddOrUpdate(v);

            //Db.SaveChanges();



            //if (work.Count > 0)
            //{
            //    foreach (var item in work)
            //    {
            //        var outno = item.OutNumber;
            //        for (int i = 0; i < outno; i++)
            //        {
            //            var v = new PackageOutboundWorkTaskDetail()
            //            {
            //                PackageOutboundWorkTaskDetailID = 32,
            //                PackageOutboundWorkTaskID = item.PackageOutboundWorkTaskID,
            //                OutOrder = i
            //            };
            //            Db.PackageOutboundWorkTaskDeatails.Add(v);
            //            Db.SaveChanges();
            //        }

            //    }
            //}


            //var v = new PackageOutboundWorkTask()
            //{
            //};
            //Db.PackageOutboundWorkTasks.Add(v);
            //Db.SaveChanges();

            //if (inventories.Count > 0)
            //{
            //    foreach (var item in inventories)
            //    {
            //        Console.WriteLine(item.AllNumber);
            //    }
            //}

            //var spoolspecinfo = Db.SpoolSpecInfos.Where(e => e.Cname == "1");

            //Test t = new Test();
            //var ss = ("6G00KU");
            //////
            //string sql = @"select A.EndWrkDate , A.WeldCount /*焊点*/ , A.LR /*正反面*/ , D.CName , C.Const , A.MachCode/*机台号*/,SampleYN/*样品号*/
            //        from tblStrandProd A Inner Join tblProdCodeStructMark B On A.StructBarCode = B.StructBarCode
            //        Inner Join tblProdCode C On B.ProdCode = C.ProdCode
            //        Inner Join tblCommon D On B.SpoolType = D.CodeID
            //        And D.GroupId = 'C06'
            //        where StrandTagNo = @StrandTagNo";
            //var results = Db1.Database.SqlQuery<SpoolSpecInfo>(sql, new SqlParameter("@StrandTagNo", ss)).ToList();

            //if (results.Count > 0)
            //{
            //    foreach (var item in results)
            //    {
            //        Console.WriteLine(item.Cname);
            //        Console.WriteLine(item.Const);
            //    }
            //}


            //Test.aa("6G00KU");
            // Test t=new Test();
            // t.aa("6G00KU");


            //var result = SQLHelper.ExecuteDataTable(sql,new SqlParameter("@StrandTagNo",s));

            //var columnNames=SQLHelper.GetColumnsByDataTable(result);
            //for (int i = 0; i < columnNames.Length; i++)
            //{
            //    Console.Write(columnNames[i]+"|");

            //}
            //Console.WriteLine();
            //for (int i = 0; i < result.Rows.Count; i++)
            //{
            //    for (int j = 0; j < result.Columns.Count; j++)
            //    {
            //        Console.Write(result.Rows[i][j].ToString()+"|");
            //    }
            //}

            //Console.WriteLine(  result.Rows.Count);

            //var l = SQLHelper.ConvertToList<SpoolSpecInfo>(result);

            //Console.WriteLine();


            //foreach (var i   in v)
            //{
            //    Console.WriteLine(v.work);
            //}

            //IGetSpoolSpecInfoRepository aa = new GetSpoolSpecInfoRepository();
            ////IGetSpoolSpecInfoRepository aa = ServiceLocator.Current.GetInstance<GetSpoolSpecInfoRepository>();
            //var a = aa.GetSpoolSpecInfo("6G00P9");
            //IPackageInventoryRepository bb = new PackageInventoryRepository();
            //var b1 = bb.GetPackageInventory(a.Cname, a.Const, a.LR);
            //if (b1 == null)
            //{
            //    var inventory = new PackageInventory()
            //    {
            //        Id=1,
            //        AllNumber = 1,
            //        SpoolSpec = a.Cname,
            //        SteelSpec = a.Const,
            //        LR = a.LR,
            //        AgingTime = 24,
            //    };
            //    bb.Update(inventory);
            //}
            //else
            //{
            //    b1.AllNumber++;
            //    bb.Update(b1);
            //}

            // var packageInventory=new PackageInventoryRepository();
            //var packageInventoryRepository = ServiceLocator.Current.GetInstance<IPackageInventoryRepository>();
            //var packageInventoryRepository=new PackageInventoryRepository(null);
            //PackageInventory packageInventory = packageInventoryRepository.GetPackageInventory("1", "1", "1");







            //while (Console.ReadLine() != "exit")
            //{
            var v = new GetSpoolSpecInfoRepository();
            var packInventory = v.GetSpoolSpecInfo(scanCode1);
            if (packInventory != null)
            {
                Console.WriteLine(packInventory.Cname);
                Console.WriteLine(packInventory.Const);
                Console.WriteLine(packInventory.EndWrkDate);
                Console.WriteLine(packInventory.LR);
                Console.WriteLine(packInventory.MachCode);
                Console.WriteLine(packInventory.SampleYN);
                Console.WriteLine(packInventory.WeldCount);
                Console.WriteLine(packInventory.ConstCode);

            }
            else Console.WriteLine("scanCode1没有数据");

            //    System.Threading.Thread.Sleep(100);

            var packInventory1 = v.GetSpoolSpecInfo(scanCode2);
            if (packInventory1 != null)
            {
                Console.WriteLine(packInventory1.Cname);
                Console.WriteLine(packInventory1.Const);
                Console.WriteLine(packInventory1.EndWrkDate);
                Console.WriteLine(packInventory1.LR);
                Console.WriteLine(packInventory1.MachCode);
                Console.WriteLine(packInventory1.SampleYN);
                Console.WriteLine(packInventory1.WeldCount);
                Console.WriteLine(packInventory1.ConstCode);
            }
            else
            {
                Console.WriteLine("scanCode2没有数据");
            }

            if ((packInventory1 == null) || (packInventory == null)
                || (packInventory.Cname != packInventory1.Cname
                    || packInventory.Const != packInventory1.Const
                    || packInventory.LR != packInventory1.LR
                    || packInventory.ConstCode != packInventory1.ConstCode))
            {
                Console.WriteLine("Not equal");
            }
            else
            {
                Console.WriteLine("equal");
            }

            Console.WriteLine("^End^");
        }
    }

    public class a
    {
        public int b;
        public int c;
    }
}
