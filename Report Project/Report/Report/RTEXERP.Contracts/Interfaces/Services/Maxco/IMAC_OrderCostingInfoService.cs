using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IMAC_OrderCostingInfoService
    {
        Task<List<BasicModel>> GETFabricComposition(string Composition);
        Task<List<Vw_MAC_IndirectCostingItem>> GetIndirectCostingItem();
        Task<List<BasicModel>> OrderDirectAccessoriesCostItem(int? TrimID, string Search);
        Task<RResult> OrderCostingSave(MAC_OrderCostingInfoVM model,int CreateBy);
        Task<RResult> OrderCostingUpdate(MAC_OrderCostingInfoVM model, int CreateBy);
        
        Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0,string OrderNo=null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetInaciveOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<SelectListItem>> DDLOrder(int BuyerID);
        Task<List<SelectListItem>> DDLStyle(string OrderName);
        Task<MAC_OrderCostingInfoVM> GetOrderCostingInfoByIDForClone(int CostingID);
        Task<RResult> RemoveCostingSheet(int ID, string Remarks,int CreateBy);

    }
}
