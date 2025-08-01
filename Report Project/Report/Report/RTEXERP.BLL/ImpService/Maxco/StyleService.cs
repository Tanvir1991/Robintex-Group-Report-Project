using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
  public  class StyleService :IStyleService
    {
        private readonly IStyleRepository styleRepository; 
        public StyleService(IStyleRepository styleRepository)
        {
            this.styleRepository = styleRepository;
        }

        public async Task<List<SelectListItem>> DDLBuyerWiseOrder(int BuyerID, DateTime? OrderCreateionFrom, DateTime? OrderCreationTo,string Predict=null)
        {
            return await this.styleRepository.DDLBuyerWiseOrder(BuyerID, OrderCreateionFrom, OrderCreationTo, Predict);
        }

        public async Task<List<SelectListItem>> DDLOrderNumbers(int fromLastDurationInMonths = 24)
        {
            return await styleRepository.DDLOrderNumbers(fromLastDurationInMonths);
        }

        public async Task<List<SelectListItem>> DDLOrderWiseStyle(int OrderID)
        {
            return await styleRepository.DDLOrderWiseStyle(OrderID);
        }
        public async Task<List<SelectListItem>> DDLOrderWiseStyleGroup(int OrderID)
        {
            return await styleRepository.DDLOrderWiseStyleGroup(OrderID);
        }
 
        public async Task<List<BasicModel>> GetOrderNumbers(string Predict)
        {
            return await styleRepository.GetOrderNumbers(Predict);
        }

        public async Task<List<OrderTotalHistoryViewModel>> GetOrderTotalHistory(string OrderID, DateTime UpToDate)
        {
            return await styleRepository.GetOrderTotalHistory(OrderID, UpToDate);
        }

        public async Task<StyleVM> GetStyleInfo(long ID)
        {
            return await styleRepository.GetStyleInfo(ID);
        }
    }
}
