using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IStyleRepository:IGenericRepository<Style>
    {
        Task<List<SelectListItem>> DDLBuyerWiseOrder(int BuyerID, DateTime? OrderCreateionFrom, DateTime? OrderCreationTo,string Predict=null);
        Task<List<SelectListItem>> DDLOrderWiseStyle(int OrderID);
        Task<List<SelectListItem>> DDLOrderWiseStyleGroup(int OrderID);
        Task<List<BasicModel>> GetOrderNumbers(string Predict);
        Task<List<OrderTotalHistoryViewModel>> GetOrderTotalHistory(string OrderID, DateTime UpToDate);
        Task<StyleVM> GetStyleInfo(long ID);
        Task<List<SelectListItem>> DDLOrderNumbers(int fromLastDurationInMonths = 24);
    }
}
