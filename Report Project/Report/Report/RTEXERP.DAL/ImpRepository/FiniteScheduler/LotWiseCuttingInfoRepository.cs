using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class LotWiseCuttingInfoRepository : GenericRepository<LotWiseCuttingInfo>, ILotWiseCuttingInfoRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public LotWiseCuttingInfoRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        public async Task<bool> CheckIfDataExistsInLotCutting(string orderNo, string color)
        {
            var list = await dbCon.LotWiseCuttingInfo
                .Where(x => x.IsRemoved == false && x.OrderNo == orderNo && x.PantoneNo == color)
                .ToListAsync();
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SelectListItem>> GetDDLOrderListForLotWiseCutting()
        {
            var OrderList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLOrderListForLotWiseCutting")
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 OrderList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                             });
                return OrderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LotWiseCuttingStatusViewModel> GetLotWiseCuttingStatus(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID)
        {
            try
            {
                var model = new LotWiseCuttingStatusViewModel();
                decimal cadAvg = 0;
                int orderQtyKg = 0;
                var _planModel = dbCon.MarkerCuttingPlanMaster_Excel
                    .Include(x => x.MarkerCuttingInfo_Excel)
                    .ThenInclude(y => y.MarkerCuttingConsumption_Excel)
                    .Include(z => z.MarkerCuttingFabricDetail_Excel)
                    .Where(x => x.OrderNo == orderNo && x.Color == color);

                if (MarkerCuttingPlanMaster_ExcelID > 0)
                {
                    _planModel = _planModel.Where(b => b.MCPMasterID == MarkerCuttingPlanMaster_ExcelID);
                }

               var planModel= await _planModel.FirstOrDefaultAsync();

                var consumptionUI = await dbCon.ConsumptionSheetUserInputs.Where(x => x.OrderNo == orderNo && x.PantoneNo == color).FirstOrDefaultAsync();
                //if (planModel.InspectionPcs == null)
                //{
                var inspectedQty = new OrderWiseOKAndDefectQuantityViewModel();
                await dbCon.LoadStoredProc("ajt.usp_GetOrderWiseOKAndDefectQuantity")
                    .WithSqlParam("OrderNo", orderNo)
                    .WithSqlParam("Color", color)
                    .ExecuteStoredProcAsync((handler) =>
                    {
                        inspectedQty = handler.ReadToList<OrderWiseOKAndDefectQuantityViewModel>().FirstOrDefault();// as List<OrderWiseOKAndDefectQuantityViewModel>;
                    });

                if (consumptionUI != null)
                {
                    model.InspectionPcs = consumptionUI.InspectionPcs == null ? inspectedQty.OKQuantity : consumptionUI.InspectionPcs.Value;
                    model.PanelRejectPcs = consumptionUI.PanelRejectPcs == null ? inspectedQty.DefectQuantity : consumptionUI.PanelRejectPcs.Value;
                    model.PanelRejectPercentage = consumptionUI.PanelRejectPercentage == null ? Math.Round(Convert.ToDecimal((model.PanelRejectPcs * 100 / model.InspectionPcs)), 2) : consumptionUI.PanelRejectPercentage.Value;
                    model.TotalFinishFabricUsed = consumptionUI.TotalFinishFabricUsed == null ? 0 : consumptionUI.TotalFinishFabricUsed.Value;
                    model.TotalFinishFabricMayReq = consumptionUI.TotalFinishFabricMayReq == null ? 0 : consumptionUI.TotalFinishFabricMayReq.Value;
                    model.ALGOOSQty = consumptionUI.ALGOOSQty == null ? 0 : consumptionUI.ALGOOSQty.Value;
                }
                else
                {
                    model.InspectionPcs = inspectedQty.OKQuantity;
                    model.PanelRejectPcs = inspectedQty.DefectQuantity;
                    model.PanelRejectPercentage = Math.Round(Convert.ToDecimal((model.PanelRejectPcs * 100 / model.InspectionPcs)), 2);
                    model.TotalFinishFabricUsed = 0;
                    model.TotalFinishFabricMayReq = 0;
                    model.ALGOOSQty = 0;
                }
                //}
                //else
                //{
                //    model.InspectionPcs = planModel.InspectionPcs.Value;
                //    model.PanelRejectPcs = planModel.PanelRejectPcs.Value;
                //    model.PanelRejectPercentage = Math.Round(Convert.ToDecimal((planModel.PanelRejectPcs.Value * 100 / planModel.InspectionPcs.Value)), 2);
                //}

                if (planModel.TotalQty > 0)
                {
                    var fabDetailConsSum = planModel.MarkerCuttingFabricDetail_Excel.Where(x => x.FabricType == "S/F").Sum(y => y.ConsKgPerDzn);
                    cadAvg = Math.Round((planModel.MarkerCuttingInfo_Excel.Where(x => x.InfoType == "Plan").First().MarkerCuttingConsumption_Excel.AvgCons + fabDetailConsSum) * planModel.TotalQty, 3);
                    if (planModel.TotalPetitQty > 0)
                    {
                        var petit = planModel.MarkerCuttingInfo_Excel.Where(x => x.InfoType == "Petit").FirstOrDefault();
                        if (petit != null)
                        {
                            cadAvg = cadAvg + (petit.MarkerCuttingConsumption_Excel.AvgCons + fabDetailConsSum) * planModel.TotalPetitQty;
                        }

                    }
                    orderQtyKg = (int)Math.Round(cadAvg / 12);
                    cadAvg = Math.Round(cadAvg / (planModel.TotalQty + planModel.TotalPetitQty), 3);

                }


                if (planModel != null)
                {
                    var _cuttingEntity =  dbCon.LotWiseCuttingInfo
                        .Include(x => x.LotWiseCuttingInfoMarkers)
                        .ThenInclude(y => y.LotWiseCuttingInfoMarkersSizes)
                        .Include(x => x.LotWiseShortCuttingInfo)
                        .Where(x => x.OrderNo == orderNo && x.PantoneNo == color);

                    if (MarkerCuttingPlanMaster_ExcelID > 0)
                    {
                        _cuttingEntity = _cuttingEntity.Where(b => (b.MarkerCuttingPlanMaster_ExcelID == MarkerCuttingPlanMaster_ExcelID) || b.MarkerCuttingPlanMaster_ExcelID.HasValue==false);
                    }


                    var cuttingEntity =await _cuttingEntity.ToListAsync();

                    var cuttingModel = mapper.Map<List<LotWiseCuttingInfo>, List<LotWiseCuttingInfoViewModel>>(cuttingEntity);

                    foreach (var itemCutting in cuttingModel)
                    {
                        itemCutting.CuttingReportingDateMsg = itemCutting.CuttingReportingDate.ToString("dd-MMM-yyyy");
                        var loop = 1;
                        foreach (var item in itemCutting.LotWiseCuttingInfoMarkers.OrderBy(x => x.MarkerSerial).ToList())
                        {

                            var markerPlan = planModel.MarkerCuttingInfo_Excel.Where(x => x.MarkerSerial == item.MarkerSerial).FirstOrDefault();
                            if (markerPlan != null)
                            {
                                if (cadAvg == 0)
                                {
                                    cadAvg = Math.Round(markerPlan.MarkerCuttingConsumption_Excel.AvgCons, 3);
                                }

                                item.CADMarkerLengthYard = markerPlan.Yrd;
                                item.CADMarkerLengthInch = markerPlan.Inch;
                            }
                            else
                            {
                                item.CADMarkerLengthYard = 0;
                                item.CADMarkerLengthInch = 0;
                            }
                            if (itemCutting.LotQuantity > 0)
                            {
                                if (loop == 1)
                                {
                                    item.CuttingTargetValue = Math.Round(((itemCutting.LotQuantity * 12) / cadAvg) * (1 + (0.03M)));
                                    item.SewingInputValue = Math.Round(((itemCutting.LotQuantity * 12) / cadAvg) * (1 + (planModel.SewingInputPercentage / 100)));
                                    item.TargetAsCADCons = Math.Round(((itemCutting.LotQuantity * 12) / cadAvg));
                                }
                                else
                                {
                                    item.CuttingTargetValue = 0;
                                    item.SewingInputValue = 0;
                                    item.TargetAsCADCons = 0;
                                }
                                loop++;
                            }
                            else
                            {
                                item.CuttingTargetValue = 0;
                                item.SewingInputValue = 0;
                                item.TargetAsCADCons = 0;
                            }
                        }
                    }
                    if (cuttingModel != null)
                    {
                        var fabDetailConsSum = planModel.MarkerCuttingFabricDetail_Excel.Where(x => x.FabricType == "S/F").Sum(y => y.ConsKgPerDzn);
                       
                        model.OrderNo = planModel.OrderNo;
                        model.Fabric = planModel.Fabric;
                        model.FabricQuality = planModel.FabricQuality;
                        model.StyleName = planModel.StyleName;
                        model.Color = planModel.Color;
                        model.Dia = planModel.Dia;
                        model.GSM = planModel.GSM;
                        model.TotalQty = planModel.TotalQty;
                        model.TotalPetitQty = planModel.TotalPetitQty;
                        model.CuttingTargetPercentage = 3;
                        model.SewingInputPercentage = planModel.SewingInputPercentage;
                        model.CostedConsUnit = planModel.CostedConsUnit;
                        model.CostedCons = planModel.CostedCons;
                        model.LotWiseCuttingInfo = cuttingModel;
                        model.LotWiseCuttingInfo.ForEach(x => { x.LotWiseCuttingInfoMarkers = x.LotWiseCuttingInfoMarkers.OrderBy(k => k.MarkerSerial).ToList(); });
                        model.LotWiseCuttingInfo.ForEach(x => x.LotWiseCuttingInfoMarkers.ForEach(m => { m.LotWiseCuttingInfoMarkersSizes = m.LotWiseCuttingInfoMarkersSizes.OrderBy(s => s.SizeSerial).ToList(); }));
                        model.CADAvg = Math.Round(cadAvg, 3);
                        model.OrderQtyKg = orderQtyKg;
                    }
                }
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> Save(LotWiseCuttingInfo entity)
        {
            RResult rResult = new RResult();
            try
            {
                RResult result = await CheckIfDataExists(entity.OrderID, entity.LotID, entity.LotQuantity, entity.CreatedBy);

                dbCon.LotWiseCuttingInfo.Add(entity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        private async Task<RResult> CheckIfDataExists(long orderID, int lotID, decimal lotQuantity, int updatedBy)
        {
            RResult result = new RResult();
            try
            {
                var cuttingData = dbCon.LotWiseCuttingInfo.Where(x => x.OrderID == orderID && x.LotID == lotID && x.LotQuantity == lotQuantity && x.IsRemoved == false).FirstOrDefault();
                if (cuttingData != null)
                {
                    var entity = dbCon.LotWiseCuttingInfo
                        .Include(x => x.LotWiseCuttingInfoMarkers)
                        .ThenInclude(y => y.LotWiseCuttingInfoMarkersSizes)
                        .Include(x => x.LotWiseShortCuttingInfo)
                        .Where(x => x.CuttingInfoID == cuttingData.CuttingInfoID)
                        .First();
                    entity.IsRemoved = true;
                    entity.UpdatedBy = updatedBy;
                    entity.UpdatedDate = DateTime.Now;
                    entity.LotWiseCuttingInfoMarkers.ForEach(x =>
                    {
                        x.IsRemoved = true; x.UpdatedBy = updatedBy; x.UpdatedDate = DateTime.Now;
                        x.LotWiseCuttingInfoMarkersSizes.ForEach(y => { y.IsRemoved = true; y.UpdatedBy = updatedBy; y.UpdatedDate = DateTime.Now; });
                    });
                    entity.LotWiseShortCuttingInfo.ForEach(x => { x.IsRemoved = true; x.UpdatedBy = updatedBy; x.UpdatedDate = DateTime.Now; });
                    await dbCon.SaveChangesAsync();

                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;

        }

        public async Task<ConsumptionSheetViewModel> GetConsumptionSheetInfo(long orderID, string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID)
        {
            var model = new ConsumptionSheetViewModel();
            var shippingInfo = new List<OrderShippingInfoViewModel>();
            var orderKrsBatch = new OrderKRSBatchInfoViewModel();
            var rejectionBreakdown = new List<OrderColorWiseRejectionBreakdown_ReportViewModel>();
            var totalAlgoQty = 0;
            decimal additionalInputReq = 0;
            try
            {
                var lotWiseCutting = await GetLotWiseCuttingStatus(orderNo, color, MarkerCuttingPlanMaster_ExcelID);

                await dbCon.LoadStoredProc("ajt.usp_GetKRSBatchInfo")
                    .WithSqlParam("OrderNo", orderNo)
                    .WithSqlParam("Color", color)
                    .WithSqlParam("FabricComposition", lotWiseCutting.Fabric)
                    .WithSqlParam("FabricQuality", lotWiseCutting.FabricQuality)
                    .WithSqlParam("GSM", lotWiseCutting.GSM)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 orderKrsBatch = handler.ReadToList<OrderKRSBatchInfoViewModel>().FirstOrDefault();
                             });

                await dbCon.LoadStoredProc("ajt.usp_GetOrderShippingInfo")
                     .WithSqlParam("OrderID", orderID)
                     .WithSqlParam("Color", color)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 shippingInfo = handler.ReadToList<OrderShippingInfoViewModel>() as List<OrderShippingInfoViewModel>;
                             });
                totalAlgoQty = shippingInfo.Sum(x => x.AlgoQty);
                if (shippingInfo.Count > 0)
                {
                    additionalInputReq = shippingInfo.First().AdditionalInputReq;
                }                    

                var rejection = await dbCon.OrderColorWiseRejectionBreakdown_Report.Where(x => x.OrderID == orderID && x.PantoneNo == color).OrderBy(x => x.DefectName).ToListAsync();
                if (rejection.Count == 0)
                {
                    await dbCon.LoadStoredProc("ajt.usp_GetOrderColorWiseRejectionBreakdown")
                     .WithSqlParam("OrderID", orderID)
                      .WithSqlParam("Color", color)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 rejectionBreakdown = handler.ReadToList<OrderColorWiseRejectionBreakdown_ReportViewModel>() as List<OrderColorWiseRejectionBreakdown_ReportViewModel>;
                             });
                }
                else
                {
                    rejectionBreakdown = mapper.Map<List<OrderColorWiseRejectionBreakdown_Report>, List<OrderColorWiseRejectionBreakdown_ReportViewModel>>(rejection);
                }
                decimal sewingValue = 0;
                var TotalActualCutQty = 0;
                decimal totalLotQty = 0;

                foreach (var itemCutting in lotWiseCutting.LotWiseCuttingInfo)
                {
                    totalLotQty = totalLotQty + itemCutting.LotQuantity;
                    var markerCount = 1;
                    foreach (var item in itemCutting.LotWiseCuttingInfoMarkers)
                    {
                        sewingValue = sewingValue + item.SewingInputValue;
                        if (markerCount == 1)
                        {
                            TotalActualCutQty = TotalActualCutQty + ((item.LotWiseCuttingInfoMarkersSizes.Sum(x => x.Quantity) * item.CuttingLayer) + itemCutting.LotWiseShortCuttingInfo.Sum(x => x.Quantity));
                        }
                        else
                        {
                            TotalActualCutQty = TotalActualCutQty + (item.LotWiseCuttingInfoMarkersSizes.Sum(x => x.Quantity) * item.CuttingLayer);
                        }
                        markerCount++;
                    }
                }

                model.OrderNo = lotWiseCutting.OrderNo;
                model.Color = lotWiseCutting.Color;
                model.FabricComposition = lotWiseCutting.Fabric;
                model.FabricQuality = lotWiseCutting.FabricQuality;
                model.GSM = lotWiseCutting.GSM;
                model.AlgoQty = lotWiseCutting.TotalQty + lotWiseCutting.TotalPetitQty;
                model.OrderQty = lotWiseCutting.OrderQtyKg;
                model.YarnInKRS = orderKrsBatch.YarnInKRS;
                //model.CompanyName = orderKrsBatch.CompanyName;
                model.CompanyShortName = orderKrsBatch.CompanyShortName;
                model.BuyerName = orderKrsBatch.BuyerName;
                model.KRSNo = "KRS-" + orderKrsBatch.KRSID;
                model.YarnInKRSPercentage = Math.Round(orderKrsBatch.YarnInKRSPercentage, 0);
                model.BatchDelivery = Math.Round(orderKrsBatch.BatchDelivery, 0);
                model.BatchBalance = Math.Round(orderKrsBatch.YarnInKRS - orderKrsBatch.BatchDelivery , 0);
                //model.DyeingPrintQty = Math.Round(orderKrsBatch.BatchDelivery, 0);
                model.DyeingPrintQty = Math.Round(orderKrsBatch.DyeingPrintQty, 0);
                model.FinishQty = Math.Round(orderKrsBatch.FinishQty, 0);
                model.ProcessLoss = Math.Round(((orderKrsBatch.DyeingPrintQty - orderKrsBatch.FinishQty) * 100) / orderKrsBatch.DyeingPrintQty, 2);
                model.DyeingBalance = Math.Round(orderKrsBatch.YarnInKRS - orderKrsBatch.DyeingPrintQty, 0);
                model.FinishQtyFromBalance = Math.Round(model.DyeingBalance - model.DyeingBalance*(model.ProcessLoss / 100), 0);//Math.Round(((orderKrsBatch.DyeingPrintQty - orderKrsBatch.FinishQty)) / orderKrsBatch.DyeingPrintQty, 0);
             
                var TotalDeliveryWillBe = Math.Round(model.FinishQty + model.FinishQtyFromBalance, 0);
                model.TotalDeliveryWillBe = TotalDeliveryWillBe;

                model.DeliveryShort = Math.Round(model.OrderQty - TotalDeliveryWillBe, 0);

                model.CADAvg = lotWiseCutting.CADAvg;
                model.SewingInputPercentage = lotWiseCutting.SewingInputPercentage+ additionalInputReq;
                //model.SewingInputValue = Math.Round( sewingValue*(1+lotWiseCutting.SewingInputPercentage/100),0);
                model.SewingInputValue = Math.Round(model.AlgoQty * (1 + model.SewingInputPercentage / 100), 0);//changed
                model.CuttingQty = TotalActualCutQty;
                model.InspectionPcs = lotWiseCutting.InspectionPcs;
                model.PanelRejectPcs = lotWiseCutting.PanelRejectPcs;
                model.PanelRejectPercentage = lotWiseCutting.PanelRejectPercentage;
                model.TotalFinishFabricUsed = lotWiseCutting.TotalFinishFabricUsed;
                //model.ActualCuttingInput = TotalActualCutQty - lotWiseCutting.PanelRejectPcs; changed
                model.ActualCuttingInput = TotalActualCutQty - (TotalActualCutQty*(model.PanelRejectPercentage/100));
                //model.InputBalanceWithReject = Math.Round((model.AlgoQty * (1 + model.SewingInputPercentage / 100)) - (TotalActualCutQty - model.PanelRejectPcs), 0);
                model.InputBalanceWithReject = Math.Round((model.SewingInputValue - model.ActualCuttingInput) * (1 + model.PanelRejectPercentage / 100), 0);// changed by sharif vai
                model.CuttingProgress = totalLotQty;
                model.CuttingProgressPercentage = (totalLotQty * 100) / model.OrderQty;
                //model.TotalCuttingReqWithReject = model.CuttingQty + model.InputBalanceWithReject; //Math.Round((model.SewingInputValue - model.ActualCuttingInput) + (model.SewingInputValue - model.ActualCuttingInput) / model.PanelRejectPercentage,0);
                //model.TotalCuttingReqWithReject = Math.Round(model.SewingInputValue * (1 + model.PanelRejectPercentage / 100), 0);// changed by sharif vai
                
                model.TotalCuttingReqWithReject = Math.Round(model.InputBalanceWithReject + model.CuttingQty,0);// changed by sharif vai // updated 05 dec 2020

                //model.TotalFinishFabricMayRequired = Math.Round(model.TotalDeliveryWillBe + ((model.InputBalanceWithReject * (lotWiseCutting.CuttingCons / 12)) - (model.TotalDeliveryWillBe - totalLotQty)), 0);
                model.CostingConsumptionPerPiece = lotWiseCutting.CostedCons>0? Math.Round(lotWiseCutting.CostedCons / 12, 3):0;
                model.BookingConsumptionPerPiece = Math.Round(lotWiseCutting.CADAvg / 12, 3);
                model.CuttingConsumptionPerPiece = Math.Round(totalLotQty / TotalActualCutQty, 3);

                //model.TotalFinishFabricMayRequired = Math.Round(model.TotalCuttingReqWithReject * model.CuttingConsumptionPerPiece, 0); chasged by sharif vai
                model.TotalFinishFabricMayRequired=lotWiseCutting.TotalFinishFabricMayReq>0? lotWiseCutting.TotalFinishFabricMayReq: Math.Round(model.TotalCuttingReqWithReject * model.CuttingConsumptionPerPiece, 0);

                //model.TotalBatchDeliveryRequired = Math.Round(model.TotalFinishFabricMayRequired + (model.TotalFinishFabricMayRequired * model.ProcessLoss / 100), 0);//changeg by sharif vai
                model.TotalBatchDeliveryRequired = Math.Round(lotWiseCutting.ALGOOSQty * (1 + model.YarnInKRSPercentage / 100),0);
                model.ALGOOSQty = lotWiseCutting.ALGOOSQty;

               

                model.FinalConsumptionPerPiece = Math.Round(model.TotalFinishFabricUsed / Convert.ToDecimal(model.AlgoQty), 3);

                model.OrderColorWiseRejectionBreakdown_Report = rejectionBreakdown;

                foreach (var item in shippingInfo)
                {

                    item.BatchDeliveryQty = Convert.ToInt32((Convert.ToDecimal(item.AlgoQty) / Convert.ToDecimal(totalAlgoQty)) * model.TotalBatchDeliveryRequired);
                    item.ReqFinishFabric = Convert.ToInt32((Convert.ToDecimal(item.AlgoQty) / totalAlgoQty) * model.TotalFinishFabricMayRequired);
                    if (orderKrsBatch.BatchDelivery > item.BatchDeliveryQty)
                    {
                        item.KnittingDeliveryQty = item.BatchDeliveryQty;
                        orderKrsBatch.BatchDelivery -= item.BatchDeliveryQty;
                        item.KnittingDeliveryBalance = 0;
                    }
                    else
                    {
                        item.KnittingDeliveryQty = orderKrsBatch.BatchDelivery;
                        
                        item.KnittingDeliveryBalance = item.BatchDeliveryQty - orderKrsBatch.BatchDelivery;
                        orderKrsBatch.BatchDelivery = 0;
                    }
                    if (TotalDeliveryWillBe > item.ReqFinishFabric)
                    {
                        item.DyeingDeliveryQty = item.ReqFinishFabric;
                        TotalDeliveryWillBe -= item.ReqFinishFabric;
                        item.DyeingDeliveryBalance = 0;
                    }
                    else
                    {
                        item.DyeingDeliveryQty = TotalDeliveryWillBe;
                        
                        item.DyeingDeliveryBalance = item.ReqFinishFabric - TotalDeliveryWillBe;
                        TotalDeliveryWillBe = 0;
                    }

                    model.CuttingShort = (int)((model.CuttingProgress / model.BookingConsumptionPerPiece) - model.CuttingQty);
                }
                model.OrderShippingInfo = shippingInfo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return model;
        }

        public async Task<ConsumptionSheetCMViewModel> GetConsumptionSheetCM(long orderID, string color, string fabricComposition, int gsm)
        {
            try
            {
                var data = new ConsumptionSheetCMViewModel();

                await dbCon.LoadStoredProc("ajt.usp_GetConsumptionSheetCM")
                        .WithSqlParam("OrderID", orderID)
                        .WithSqlParam("PantoneNo", color)
                        .WithSqlParam("FabricComposition", fabricComposition)
                        .WithSqlParam("GSM", gsm)
                                 .ExecuteStoredProcAsync((handler) =>
                                 {
                                     data = handler.ReadToList<ConsumptionSheetCMViewModel>().FirstOrDefault();
                                 });
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<RResult> DeleteLotInfo(long orderId,string color, int lotId, decimal lotQuantity,int updatedBy)
        {
            RResult rResult = new RResult();
            try
            {
                var cuttingEntity = await dbCon.LotWiseCuttingInfo
                        .Include(x => x.LotWiseCuttingInfoMarkers)
                        .ThenInclude(y => y.LotWiseCuttingInfoMarkersSizes)
                        .Include(x => x.LotWiseShortCuttingInfo)
                        .Where(x => x.OrderID == orderId && x.PantoneNo == color && x.LotID==lotId && x.LotQuantity==lotQuantity)
                            .FirstOrDefaultAsync();
                if (cuttingEntity!=null)
                {
                    cuttingEntity.IsActive = false;
                    cuttingEntity.IsRemoved = true;
                    cuttingEntity.UpdatedBy = updatedBy;
                    cuttingEntity.UpdatedDate = DateTime.Now;
                    cuttingEntity.LotWiseCuttingInfoMarkers.ForEach(x => { x.IsActive = false; x.IsRemoved = true;x.UpdatedBy = updatedBy;x.UpdatedDate = DateTime.Now;
                        x.LotWiseCuttingInfoMarkersSizes.ForEach(y => { y.IsActive = false; y.IsRemoved = true; y.UpdatedBy = updatedBy; y.UpdatedDate = DateTime.Now; });
                    });
                    cuttingEntity.LotWiseShortCuttingInfo.ForEach(z => { z.IsActive = false; z.IsRemoved = true; z.UpdatedBy = updatedBy; z.UpdatedDate = DateTime.Now; });
                }
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<List<LotWiseCuttingStatusSearchResultViewModel>> GetLotWiseCuttingStatusSearchResult(string dateFrom, string dateTo, string orderNo, string color,int MarkerCuttingPlanMasterID)
        {
            var OrderList = new List<LotWiseCuttingStatusSearchResultViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetLotWiseCuttingStatusSearchResult")
                    .WithSqlParam("ReportDateFrom", dateFrom)
                    .WithSqlParam("ReportDateTo", dateTo)
                    .WithSqlParam("OrderNo", orderNo)
                    .WithSqlParam("Color", color)
                    .WithSqlParam("MarkerCuttingPlanMasterID", MarkerCuttingPlanMasterID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 OrderList = handler.ReadToList<LotWiseCuttingStatusSearchResultViewModel>() as List<LotWiseCuttingStatusSearchResultViewModel>;
                             });
                return OrderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
