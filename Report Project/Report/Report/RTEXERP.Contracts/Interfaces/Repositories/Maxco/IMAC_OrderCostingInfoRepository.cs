using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IMAC_OrderCostingInfoRepository :IGenericRepository<MAC_OrderCostingInfo>
    {
        Task<MAC_OrderCostingInfo> GetMAC_OrderCostingInfoByOrderNo(string orderNo);
        Task<List<BasicModel>> GETFabricComposition(string Composition);
        Task<List<Vw_MAC_IndirectCostingItem>> GetIndirectCostingItem();
        Task<List<BasicModel>> OrderDirectAccessoriesCostItem(int? TrimID, string Search);
        Task<RResult> OrderCostingSave(MAC_OrderCostingInfo model);
        Task<RResult> OrderCostingUpdate(MAC_OrderCostingInfoVM model,int CreateBy);
        
        Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0,string OrderNo=null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetInaciveOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<SelectListItem>> DDLOrder(int BuyerID);
        Task<List<SelectListItem>> DDLStyle(string OrderName);
        Task<MAC_OrderCostingInfoVM> GetOrderCostingInfoByIDForClone(int CostingID);

        Task<List<SelectListItem>> DDLCostingOrder(int? BuyerID,DateTime? DateFrom,DateTime? DateTo);
        Task<RResult> RemoveCostingSheet(int ID,string Remarks, int UpdateBy);



    }
}
