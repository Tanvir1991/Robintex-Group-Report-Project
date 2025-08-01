using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.Drawing.Chart;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class LotWiseCuttingInfoService : ILotWiseCuttingInfoService
    {
        private readonly IMapper mapper;
        private readonly ILotWiseCuttingInfoRepository lotWiseCuttingInfoRepository;
        private readonly IMAC_OrderCostingInfoRepository mAC_OrderCostingInfoRepository;

        public LotWiseCuttingInfoService(IMapper mapper,ILotWiseCuttingInfoRepository lotWiseCuttingInfoRepository
            , IMAC_OrderCostingInfoRepository mAC_OrderCostingInfoRepository)
        {
            this.mapper = mapper;
            this.lotWiseCuttingInfoRepository = lotWiseCuttingInfoRepository;
            this.mAC_OrderCostingInfoRepository = mAC_OrderCostingInfoRepository;
        }

        public async Task<bool> CheckIfDataExistsInLotCutting(string orderNo, string color)
        {
            return await lotWiseCuttingInfoRepository.CheckIfDataExistsInLotCutting(orderNo, color);
        }

        public async Task<RResult> DeleteLotInfo(long orderId, string color, int lotId, decimal lotQuantity, int updatedBy)
        {
            return await lotWiseCuttingInfoRepository.DeleteLotInfo(orderId, color, lotId, lotQuantity, updatedBy);
        }

        public async Task<ConsumptionSheetViewModel> GetConsumptionSheetInfo(long orderID,string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID)
        {
            var data= await lotWiseCuttingInfoRepository.GetConsumptionSheetInfo(orderID,orderNo, color, MarkerCuttingPlanMaster_ExcelID);
            data.ConsumptionSheetCM = await lotWiseCuttingInfoRepository.GetConsumptionSheetCM(orderID,color, data.FabricComposition,data.GSM);
            data.ConsumptionSheetCM.AdditionalFabricQty =  (int)data.ALGOOSQty- data.OrderQty;// reversed by Sharif vai
            data.ConsumptionSheetCM.AdditionalFabricValue =(data.ConsumptionSheetCM.AdditionalFabricQty) * data.ConsumptionSheetCM.FabricCostPerKG;
            //if (data.ConsumptionSheetCM.AdditionalFabricQty > 0)
            //{
                data.ConsumptionSheetCM.ReviseCM = Math.Round(data.ConsumptionSheetCM.ALGOCM - (data.ConsumptionSheetCM.AdditionalFabricValue * 12 / data.ConsumptionSheetCM.TotalOrderQty),3);
            //}
            //else
            //{
            //    data.ConsumptionSheetCM.ReviseCM = Math.Round(data.ConsumptionSheetCM.ALGOCM + (data.ConsumptionSheetCM.AdditionalFabricValue * 12 / data.ConsumptionSheetCM.TotalOrderQty),3);
            //}
            var smvEfficiencyQupt = await mAC_OrderCostingInfoRepository.GetMAC_OrderCostingInfoByOrderNo(orderNo);
            if (smvEfficiencyQupt!=null)
            {
                data.ConsumptionSheetCM.FabricConsumptionKGPerDzn = smvEfficiencyQupt.FabricConsumptionPerDzn == null ? 0 : smvEfficiencyQupt.FabricConsumptionPerDzn.Value;
                data.ConsumptionSheetCM.CPM = smvEfficiencyQupt.CPM==null?0: smvEfficiencyQupt.CPM.Value;
                data.ConsumptionSheetCM.SMV = smvEfficiencyQupt.SMV==null?0: smvEfficiencyQupt.SMV.Value;
                data.ConsumptionSheetCM.Efficiency = smvEfficiencyQupt.Efficiency==null?0: smvEfficiencyQupt.Efficiency.Value;
               var quotationCM = smvEfficiencyQupt.MAC_AccessoriesCostingInfo.Where(x => x.CostingItemID == 4).FirstOrDefault();
                if (quotationCM!=null)
                {
                    data.ConsumptionSheetCM.QuotationCM = quotationCM.CostRate;
                }
                if (data.ConsumptionSheetCM.Efficiency>0)
                {
                    data.ConsumptionSheetCM.SMVCM = Math.Round( (smvEfficiencyQupt.SMV.Value * 12 * 0.035M) / (smvEfficiencyQupt.Efficiency.Value/100),3);
                }
                else
                {
                    data.ConsumptionSheetCM.SMVCM = 0;
                }
                
            }

            return data;
        }

        public async Task<List<SelectListItem>> GetDDLOrderListForLotWiseCutting()
        {
            return await lotWiseCuttingInfoRepository.GetDDLOrderListForLotWiseCutting();
        }

        public async Task<LotWiseCuttingStatusViewModel> GetLotWiseCuttingStatus(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID)
        {
            return await lotWiseCuttingInfoRepository.GetLotWiseCuttingStatus(orderNo, color, MarkerCuttingPlanMaster_ExcelID);
        }

        public async Task<List<LotWiseCuttingStatusSearchResultViewModel>> GetLotWiseCuttingStatusSearchResult(string dateFrom, string dateTo, string orderNo, string color,int MarkerCuttingPlanMasterID)
        {
            return await lotWiseCuttingInfoRepository.GetLotWiseCuttingStatusSearchResult(dateFrom, dateTo, orderNo, color, MarkerCuttingPlanMasterID);
        }

        public async Task<RResult> Save(LotWiseCuttingInfoViewModel model)
        {
            var entity = mapper.Map<LotWiseCuttingInfoViewModel, LotWiseCuttingInfo>(model);

            var rResult = await lotWiseCuttingInfoRepository.Save(entity);
            return rResult;
        }
    }
}
