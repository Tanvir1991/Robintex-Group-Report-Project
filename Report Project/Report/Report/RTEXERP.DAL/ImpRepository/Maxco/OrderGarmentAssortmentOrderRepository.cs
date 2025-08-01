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
   public class OrderGarmentAssortmentOrderRepository : GenericRepository<Style>, IOrderGarmentAssortmentOrderRepository
    {
        private MaxcoDBContext dbCon;

        public OrderGarmentAssortmentOrderRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>> Get_OrderGarmentAssortmentOrder_StyeAndSize(int StyleID)
        {
            var itemList = new List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.Get_OrderGarmentAssortmentOrder_StyeAndSize")
                                .WithSqlParam("StyleID", StyleID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>() as List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>;
                             });

                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
