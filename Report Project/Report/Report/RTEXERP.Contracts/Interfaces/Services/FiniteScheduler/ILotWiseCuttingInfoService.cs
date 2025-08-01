using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface ILotWiseCuttingInfoService
    {
        Task<List<SelectListItem>> GetDDLOrderListForLotWiseCutting();
        Task<RResult> Save(LotWiseCuttingInfoViewModel model);
        Task<bool> CheckIfDataExistsInLotCutting(string orderNo, string color);
        Task<LotWiseCuttingStatusViewModel> GetLotWiseCuttingStatus(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID);
        Task<ConsumptionSheetViewModel> GetConsumptionSheetInfo(long orderID,string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID);
        Task<RResult> DeleteLotInfo(long orderId, string color, int lotId, decimal lotQuantity, int updatedBy);
        Task<List<LotWiseCuttingStatusSearchResultViewModel>> GetLotWiseCuttingStatusSearchResult(string dateFrom, string dateTo, string orderNo, string color,int MarkerCuttingPlanMasterID);



    }
}
