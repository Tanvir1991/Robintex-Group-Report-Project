using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class vw_OrderLotFinishQuantityRepository : GenericRepository<vw_OrderLotFinishQuantity>, Ivw_OrderLotFinishQuantityRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public vw_OrderLotFinishQuantityRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color)
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            lotList = await dbCon.vw_OrderLotFinishQuantity
                .Where(x => x.OrderID == orderID && x.PantoneNo== color)
                .Select(r => new SelectListItem()
                {
                    Text = r.LotNo,
                    Value = r.LotID.ToString()
                }).ToListAsync();
            return lotList;
        }

        public async Task<vw_OrderLotFinishQuantity> GetOrderWiseLotFinishQuantity(int orderID, long lotID)
        {
            vw_OrderLotFinishQuantity lotDetails = new vw_OrderLotFinishQuantity();
            try
            {
                lotDetails = await dbCon.vw_OrderLotFinishQuantity
                .Where(x => x.OrderID == orderID && x.LotID == lotID)
                .FirstAsync();
                return lotDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
