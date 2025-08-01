using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class KRS_MASTERRepository : GenericRepository<KRS_MASTER>, IKRS_MASTERRepository
    {
        private MaxcoDBContext dbCon;

        public KRS_MASTERRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<KRSOrderFabricSPModel>> GetKRSOrderFabricList(int kRSID = 0, int orderID = 0)
        {
            var krsFabricList = new List<KRSOrderFabricSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.GetKRS_Order_FabricList")
                             .WithSqlParam("KRSID", kRSID)
                             .WithSqlParam("OrderID", orderID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                krsFabricList = handler.ReadToList<KRSOrderFabricSPModel>() as List<KRSOrderFabricSPModel>;
                             });
               
                return krsFabricList !=null? krsFabricList:new List<KRSOrderFabricSPModel>();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
