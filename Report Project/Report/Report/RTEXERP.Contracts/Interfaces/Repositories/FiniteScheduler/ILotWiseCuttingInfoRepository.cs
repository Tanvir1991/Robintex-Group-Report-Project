using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface ILotWiseCuttingInfoRepository:IGenericRepository<LotWiseCuttingInfo>
    {
        Task<List<SelectListItem>> GetDDLOrderListForLotWiseCutting();
        Task<RResult> Save(LotWiseCuttingInfo entity);
        Task<bool> CheckIfDataExistsInLotCutting(string orderNo, string color);
        Task<LotWiseCuttingStatusViewModel> GetLotWiseCuttingStatus(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID);
        Task<ConsumptionSheetViewModel> GetConsumptionSheetInfo(long orderID,string orderNo, string color, int MarkerCuttingPlanMaster_ExcelID);
        Task<ConsumptionSheetCMViewModel> GetConsumptionSheetCM(long orderID, string color,string fabricComposition,int gsm);
        Task<RResult> DeleteLotInfo(long orderId, string color, int lotId, decimal lotQuantity, int updatedBy);
        Task<List<LotWiseCuttingStatusSearchResultViewModel>> GetLotWiseCuttingStatusSearchResult(string dateFrom, string dateTo, string orderNo, string color,int MarkerCuttingPlanMasterID);
    }
}
