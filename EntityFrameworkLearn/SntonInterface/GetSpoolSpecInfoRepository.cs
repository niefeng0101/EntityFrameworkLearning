using System.Data.SqlClient;
using System.Linq;
using Kengic.Was.Domain.Entity.SntonInterface;
using Kengic.Was.Domain.Model.SntonInterface;

namespace Kengic.Was.Domain.SntonInterface
{
    public class GetSpoolSpecInfoRepository : IGetSpoolSpecInfoRepository
    {
        readonly SntonMesInterface _sntoninterface = new SntonMesInterface();
        public SpoolSpecInfo GetSpoolSpecInfo(string strandTagNo)
        {
            const string querySql = @"select A.EndWrkDate , 
                       A.WeldCount /*焊点*/ , 
                       A.LR /*正反面*/ , 
                       D.CName , 
                       C.Const , 
                       A.MachCode/*机台号*/,
                       SampleYN/*样品号*/,
                       C.ProdCode/*품목코드*/,
                       A.Length/*길이*/,
                       A.EndUser/*작업자*/,
                       E.ConstCode/*구조코드*/,
                       A.SampleNo/*샘플번호*/
                        from tblStrandProd A Inner Join tblProdCodeStructMark B On A.StructBarCode = B.StructBarCode
                     Inner Join tblProdCode C On B.ProdCode = C.ProdCode
                     Inner Join tblCommon D On B.SpoolType = D.CodeID And D.GroupID = 'C06'
					 Left Outer Join tblProdBpwDia E On B.ProdCode  = E.ProdCode And B.BuyerCode = E.BuyerCode
                        where StrandTagNo =  @StrandTagNo";

            var results = _sntoninterface.Database.SqlQuery<SpoolSpecInfo>(querySql, new SqlParameter("@StrandTagNo", strandTagNo)).ToList();
            return results.Count > 0 ? results[0] : null;

        }
    }
}