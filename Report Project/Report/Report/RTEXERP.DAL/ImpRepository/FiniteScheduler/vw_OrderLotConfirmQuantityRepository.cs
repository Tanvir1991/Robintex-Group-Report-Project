using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class vw_OrderLotConfirmQuantityRepository : GenericRepository<vw_OrderLotConfirmQuantity>, Ivw_OrderLotConfirmQuantityRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public vw_OrderLotConfirmQuantityRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color)
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            lotList = await dbCon.vw_OrderLotConfirmQuantity
                .Where(x => x.OrderID == orderID && x.PantoneNo == color)
                .Select(r => new SelectListItem()
                {
                    Text = r.LotNo,
                    Value = r.LotID.ToString()
                }).ToListAsync();
            return lotList;
        }
    }
}
