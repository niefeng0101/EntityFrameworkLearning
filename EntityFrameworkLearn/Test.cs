using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLearn
{
    public  class Test
    {
        // readonly  SntonContext Db = new SntonContext();

        //public  void aa(string ss)
        //{
        //    //string s = Console.ReadLine();//"6G00KU";// "6F001D";

        //    string sql = @"select A.EndWrkDate , A.WeldCount /*焊点*/ , A.LR /*正反面*/ , D.CName , C.Const , A.MachCode/*机台号*/,SampleYN/*样品号*/
        //            from tblStrandProd A Inner Join tblProdCodeStructMark B On A.StructBarCode = B.StructBarCode
        //            Inner Join tblProdCode C On B.ProdCode = C.ProdCode
        //            Inner Join tblCommon D On B.SpoolType = D.CodeID
        //            And D.GroupId = 'C06'
        //            where StrandTagNo = @StrandTagNo";
        //    var results = Db.Database.SqlQuery<SpoolSpecInfo>(sql, new SqlParameter("@StrandTagNo", ss)).ToList();

        //    if (results.Count > 0)
        //    {
        //        foreach (var item in results)
        //        {
        //            Console.WriteLine(item.Cname);
        //            Console.WriteLine(item.Const);
        //        }
        //    }
        //}
    }
}
