using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
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
    public class MarkerCuttingPlanMaster_ExcelService : IMarkerCuttingPlanMaster_ExcelService
    {
        private readonly ILotWiseCuttingInfoService lotWiseCuttingInfoService;
        private readonly IMarkerCuttingPlanMaster_ExcelRepository markerCuttingPlanMaster_ExcelRepository;
        private readonly IConsumptionSheetUserInputsRepository consumptionSheetUserInputsRepository;
        private readonly IOrderColorWiseRejectionBreakdown_ReportRepository orderColorWiseRejectionBreakdown_ReportRepository;
        private readonly ILogger<MarkerCuttingPlanMaster_ExcelService> logger;
        private readonly IMAC_OrderCostingInfoRepository iMAC_OrderCostingInfoRepository;
        public MarkerCuttingPlanMaster_ExcelService(ILotWiseCuttingInfoService lotWiseCuttingInfoService,
            IMarkerCuttingPlanMaster_ExcelRepository markerCuttingPlanMaster_ExcelRepository
            , ILogger<MarkerCuttingPlanMaster_ExcelService> logger, IConsumptionSheetUserInputsRepository consumptionSheetUserInputsRepository
            , IOrderColorWiseRejectionBreakdown_ReportRepository orderColorWiseRejectionBreakdown_ReportRepository
            , IMAC_OrderCostingInfoRepository iMAC_OrderCostingInfoRepository)
        {
            this.logger = logger;
            this.lotWiseCuttingInfoService = lotWiseCuttingInfoService;
            this.markerCuttingPlanMaster_ExcelRepository = markerCuttingPlanMaster_ExcelRepository;
            this.consumptionSheetUserInputsRepository = consumptionSheetUserInputsRepository;
            this.orderColorWiseRejectionBreakdown_ReportRepository = orderColorWiseRejectionBreakdown_ReportRepository;
            this.iMAC_OrderCostingInfoRepository = iMAC_OrderCostingInfoRepository;
        }

        public async Task<List<SelectListItem>> DDLOrderWiseColor(string orderNo)
        {
            return await markerCuttingPlanMaster_ExcelRepository.DDLOrderWiseColor(orderNo);
        }

        public async Task<List<DropDownItem>> DDLOrderWiseColorCustome(string orderNo)
        {
            return await markerCuttingPlanMaster_ExcelRepository.DDLOrderWiseColorCustome(orderNo);
        }

        public async Task<List<SelectListItem>> DDLOrderWiseMarker(string orderNo)
        {
            return await markerCuttingPlanMaster_ExcelRepository.DDLOrderWiseMarker(orderNo);
        }

        public async Task<RResult> LotWiseCuttingInfoUpdate(ConsumptionSheetUpdateViewModel updateModel)
        {
            var result= await consumptionSheetUserInputsRepository.ConsumptionSheetUserInputsSave(updateModel.ConsumptionSheetUserInputs);
            var rresult = await orderColorWiseRejectionBreakdown_ReportRepository.OrderColorWiseRejectionBreakdown_ReportSave(updateModel.OrderColorWiseRejectionBreakdown_Report);
            return rresult;
        }

        public async Task<RResult> MarkerCuttingPlanMaster_ExcelSave(ExcelPackage package, int uploadedBy)
        {
            RResult rResult = new RResult();
            string _sl = "";
            try
            {
                var planMaster = new MarkerCuttingPlanMaster_Excel();
                int consumptionObjSerial = 0;
              
                foreach (var sheet in package.Workbook.Worksheets)
                {

                    if (sheet.Name == "Plan" || sheet.Name == "Petit")
                    {
                        var rowCount = sheet.Dimension.Rows;
                        var columnCount = sheet.Dimension.Columns;

                        var masterTableProperty = "";

                        var cuttingInfo = new MarkerCuttingInfo_Excel();
                        var curringSizes = new List<MarkerCuttingSizes_Excel>();
                        var cuttingConsumption = new MarkerCuttingConsumption_Excel();
                        var cuttingFabricDetail = new MarkerCuttingFabricDetail_Excel();
                        var readType = "Master";
                        //if (sheet.Name == "Petit")
                        //{
                        //    readType = "";
                        //}



                        int indexYrd = 0;
                        int indexInch = 0;
                        int indexDiaInch = 0;
                        int indexGSM = 0;
                        int indexRibCollar = 0;
                        int indexDzzn = 0;
                        int indexWithWastage = 0;
                        int indexRefNo = 0;
                        int indexMEffi = 0;
                        int indexTotalMarkerReq = 0;

                        int indexBaseQty = 0;
                        int indexConsPerPcs = 0;
                        int indexAvgCons = 0;
                        decimal avgConsumption = 0;

                        int indexPieceName = 0;
                        int indexFabricType = 0;
                        int indexFabGSM = 0;
                        int indexFabDia = 0;
                        int indexConsKgPerDzn = 0;


                        int sizesRowIndex = 0;
                        int consumptionRowIndex = 0;
                        int detailRowIndex = 0;


                        for (int row = 1; row <= rowCount; row++)
                        {
                            for (int column = 1; column <= columnCount; column++)
                            {
                                _sl = $"Row={row} Column={column}";
                                var value = sheet.Cells[row, column].Value;
                                if (column == 1 && value != null)
                                {
                                    if (value.ToString() == "Garments Size")
                                    {
                                        readType = "Info";
                                        sizesRowIndex = row + 1;
                                    }
                                    else if (value.ToString() == "Size")
                                    {
                                        readType = "Consumption";
                                        consumptionRowIndex = row + 2;
                                    }
                                    else if (value.ToString() == "Others Fabric Details")
                                    {
                                        readType = "FabricDetails";
                                        detailRowIndex = row + 2;
                                    }
                                }

                                #region Master 
                                if (sheet.Name == "Plan")
                                {
                                    if (readType == "Master" && value != null)
                                    {
                                        // set property value
                                        if (masterTableProperty == "OrderNo")
                                        {
                                            planMaster.OrderNo = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "Date")
                                        {
                                            planMaster.Date = Convert.ToDateTime(value.ToString());
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "StyleName")
                                        {
                                            planMaster.StyleName = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "TOD")
                                        {
                                            planMaster.TOD = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "Fabric")
                                        {
                                            planMaster.Fabric = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "Color")
                                        {
                                            planMaster.Color = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "GSM")
                                        {
                                            planMaster.GSM = Convert.ToInt32(value);
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "CuttingDirection")
                                        {
                                            planMaster.CuttingDirection = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "CostedCons")
                                        {
                                            planMaster.CostedCons = Convert.ToDecimal(value);
                                            planMaster.CostedConsUnit = "Kg/Dzn";
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "SewingInputPercent")
                                        {
                                            planMaster.SewingInputPercentage = Convert.ToDecimal(value);
                                            masterTableProperty = "";
                                        }//SewingInputPercent
                                        else if (masterTableProperty == "Dia")
                                        {
                                            planMaster.Dia = Convert.ToInt32(value);
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "FabricQuality")
                                        {
                                            planMaster.FabricQuality = value.ToString();
                                            masterTableProperty = "";
                                        }
                                        else if (masterTableProperty == "TotalQty")
                                        {
                                            planMaster.TotalQty = Convert.ToInt32(value);
                                            masterTableProperty = "";
                                        }



                                        //Set property name
                                        if (value.ToString() == "Order No:")
                                        {
                                            masterTableProperty = "OrderNo";
                                        }
                                        else if (value.ToString() == "Date")
                                        {
                                            masterTableProperty = "Date";
                                        }
                                        else if (value.ToString() == "Style Name:")
                                        {
                                            masterTableProperty = "StyleName";
                                        }
                                        else if (value.ToString() == "TOD")
                                        {
                                            masterTableProperty = "TOD";
                                        }
                                        else if (value.ToString() == "Fabric:")
                                        {
                                            masterTableProperty = "Fabric";
                                        }
                                        else if (value.ToString() == "Color")
                                        {
                                            masterTableProperty = "Color";
                                        }
                                        else if (value.ToString() == "GSM:")
                                        {
                                            masterTableProperty = "GSM";
                                        }
                                        else if (value.ToString() == "Cutting Direction")
                                        {
                                            masterTableProperty = "CuttingDirection";
                                        }
                                        else if (value.ToString() == "Costed Con's")
                                        {
                                            masterTableProperty = "CostedCons";
                                        }
                                        else if (value.ToString() == "Sewing Input Percent")
                                        {
                                            masterTableProperty = "SewingInputPercent";
                                        }//Sewing Input percent		

                                        else if (value.ToString() == "Dia:")
                                        {
                                            masterTableProperty = "Dia";
                                        }
                                        else if (value.ToString() == "Total Qty")
                                        {
                                            masterTableProperty = "TotalQty";
                                        }
                                        else if (value.ToString() == "Fabric Quality")
                                        {
                                            masterTableProperty = "FabricQuality";
                                        }
                                    }
                                }

                                if (sheet.Name == "Petit")
                                {
                                    if (readType == "Master" && value != null)
                                    {
                                        if (masterTableProperty == "TotalPetitQty")
                                        {
                                            planMaster.TotalPetitQty = Convert.ToInt32(value);
                                            masterTableProperty = "";
                                        }
                                        if (value.ToString() == "Total Qty")
                                        {
                                            masterTableProperty = "TotalPetitQty";
                                        }
                                    }
                                }
                                #endregion Master

                                #region Info
                                if (readType == "Info" && column == 1 && value == null)
                                {
                                    if (curringSizes.Count > 0)
                                    {
                                        cuttingInfo.MarkerCurringSizes_Excel = curringSizes;
                                        cuttingInfo.InfoType = sheet.Name;
                                        cuttingInfo.MarkerSerial = planMaster.MarkerCuttingInfo_Excel.Count + 1;
                                        planMaster.MarkerCuttingInfo_Excel.Add(cuttingInfo);
                                        curringSizes = new List<MarkerCuttingSizes_Excel>();
                                        cuttingInfo = new MarkerCuttingInfo_Excel();
                                        sizesRowIndex = row + 1;
                                    }

                                }
                                if (readType == "Info" && value != null)
                                {
                                    if (value.ToString() == "Yrd")
                                    {
                                        indexYrd = column;
                                    }
                                    else if (value.ToString() == "Inch")
                                    {
                                        indexInch = column;
                                    }
                                    else if (value.ToString() == "Dia Inch")
                                    {
                                        indexDiaInch = column;
                                    }
                                    else if (value.ToString() == "GSM")
                                    {
                                        indexGSM = column;
                                    }
                                    else if (value.ToString() == "Rib/Collar")
                                    {
                                        indexRibCollar = column;
                                    }
                                    else if (value.ToString() == "Dzzn")
                                    {
                                        indexDzzn = column;
                                    }
                                    else if (value.ToString() == "Weastes 6%")
                                    {
                                        indexWithWastage = column;
                                    }
                                    else if (value.ToString() == "Marker /Ref.No")
                                    {
                                        indexRefNo = column;
                                    }
                                    else if (value.ToString() == "M-Effi")
                                    {
                                        indexMEffi = column;
                                    }
                                    else if (value.ToString() == "Total Marker Req.")
                                    {
                                        indexTotalMarkerReq = column;
                                    }


                                    if (row == sizesRowIndex && column < indexYrd && Convert.ToDecimal(sheet.Cells[row + 1, indexTotalMarkerReq].Value) > 0 && value.ToString() != "0")
                                    {

                                        var size = new MarkerCuttingSizes_Excel()
                                        {
                                            Size = value.ToString(),
                                            SizeSerial = column
                                        };
                                        curringSizes.Add(size);


                                    }
                                    if (column < indexYrd - 1 && row == sizesRowIndex + 1 && Convert.ToDecimal(sheet.Cells[row, indexTotalMarkerReq].Value) > 0 && value.ToString() != "0")
                                    {
                                        curringSizes.Where(x => x.SizeSerial == column).First().SizeValue = Convert.ToInt32(value);
                                    }
                                    else if (column >= indexYrd && row == sizesRowIndex + 1 && Convert.ToDecimal(sheet.Cells[row, indexTotalMarkerReq].Value) > 0)
                                    {
                                        if (column == indexYrd)
                                        {
                                            cuttingInfo = new MarkerCuttingInfo_Excel();
                                            cuttingInfo.Yrd = Convert.ToInt32(value);
                                        }
                                        else if (column == indexInch) { cuttingInfo.Inch = Convert.ToInt32(value); }
                                        else if (column == indexDiaInch) { cuttingInfo.DiaInch = Convert.ToInt32(value); }
                                        else if (column == indexGSM) { cuttingInfo.GSM = Convert.ToInt32(value); }
                                        else if (column == indexRibCollar) { cuttingInfo.RibCollar = Convert.ToDecimal(value); }
                                        else if (column == indexDzzn) { cuttingInfo.Dzzn = Convert.ToDecimal(value); }
                                        else if (column == indexWithWastage) { cuttingInfo.WithWastage = Convert.ToDecimal(value); }
                                        else if (column == indexRefNo) { cuttingInfo.RefNo = value.ToString(); }
                                        else if (column == indexMEffi) { cuttingInfo.MEffi = Convert.ToInt32(value); }
                                        else if (column == indexTotalMarkerReq) { cuttingInfo.TotalMarkerReq = Convert.ToDecimal(value); }
                                    }
                                }

                                #endregion Info

                                #region Consumption

                                if (readType == "Consumption" && value != null)
                                {
                                    if (value.ToString() == "Base Qty")
                                    {
                                        indexBaseQty = column;
                                    }
                                    else if (value.ToString() == "Con's/Pcs")
                                    {
                                        indexConsPerPcs = column;
                                    }
                                    else if (value.ToString() == "Average Con's")
                                    {
                                        indexAvgCons = column;
                                    }

                                    if (row == consumptionRowIndex && Convert.ToDecimal(sheet.Cells[row, indexBaseQty].Value) > 0)
                                    {

                                        if (column == indexBaseQty)
                                        {
                                            cuttingConsumption = new MarkerCuttingConsumption_Excel();
                                            cuttingConsumption.BaseQty = Convert.ToInt32(value);
                                            cuttingConsumption.AvgCons = avgConsumption;
                                        }
                                        else if (column == indexConsPerPcs)
                                        {
                                            cuttingConsumption.ConsPerPcs = Convert.ToDecimal(value);
                                            if (avgConsumption == 0)
                                            {
                                                var avg = sheet.Cells[row, indexAvgCons].Value;
                                                if (avg != null)
                                                {
                                                    avgConsumption = Convert.ToDecimal(avg);
                                                }
                                            }
                                            if (avgConsumption > 0)
                                            {
                                                cuttingConsumption.AvgCons = avgConsumption;

                                                consumptionObjSerial += 1;
                                                planMaster.MarkerCuttingInfo_Excel.Where(x => x.MarkerSerial == consumptionObjSerial).First().MarkerCuttingConsumption_Excel = cuttingConsumption;
                                                cuttingConsumption = new MarkerCuttingConsumption_Excel();
                                                consumptionRowIndex += 3;
                                            }
                                        }


                                    }
                                }
                                #endregion Consumption

                                #region FabricDetails
                                if (sheet.Name == "Plan")
                                {
                                    if (readType == "FabricDetails" && value != null)
                                {

                                    if (value.ToString() == "Piece Name")
                                    {
                                        indexPieceName = column;
                                    }
                                    else if (value.ToString() == "Fabric Type")
                                    {
                                        indexFabricType = column;
                                    }
                                    else if (value.ToString() == "GSM")
                                    {
                                        indexFabGSM = column;
                                    }
                                    else if (value.ToString() == "DIA")
                                    {
                                        indexFabDia = column;
                                    }
                                    else if (value.ToString() == "Con's Kgs/Dzn")
                                    {
                                        indexConsKgPerDzn = column;
                                    }
                                    if (row >= detailRowIndex && Convert.ToDecimal(sheet.Cells[row, indexConsKgPerDzn].Value) > 0)
                                    {
                                        if (column == indexPieceName)
                                        {
                                            cuttingFabricDetail = new MarkerCuttingFabricDetail_Excel();
                                            cuttingFabricDetail.PieceName = value.ToString();
                                        }
                                        else if (column == indexFabricType) { cuttingFabricDetail.FabricType = value.ToString(); }
                                        else if (column == indexFabGSM) { cuttingFabricDetail.GSM = Convert.ToInt32(value); }
                                        else if (column == indexFabDia) { cuttingFabricDetail.Dia = Convert.ToInt32(value); }
                                        else if (column == indexConsKgPerDzn)
                                        {
                                            cuttingFabricDetail.ConsKgPerDzn = Convert.ToDecimal(value);
                                            planMaster.MarkerCuttingFabricDetail_Excel.Add(cuttingFabricDetail);

                                        }
                                    }
                                }
                                }

                                #endregion FabricDetails
                            }

                        }

                    }
                }
                planMaster.ExcelUploadDate = DateTime.Now;
                planMaster.UploadedBy = uploadedBy;
                /*
                if (!await CheckIfDataExistsInLotCutting(planMaster.OrderNo, planMaster.Color))
                {
                    rResult = await markerCuttingPlanMaster_ExcelRepository.MarkerCuttingPlanMaster_ExcelRemove(planMaster.OrderNo, planMaster.Color);
                    if (rResult.result == 1)
                    {*/
                        decimal costedCons = 0;
                        var costingInfo = await iMAC_OrderCostingInfoRepository.GetMAC_OrderCostingInfoByOrderNo(planMaster.OrderNo);
                        if (costingInfo!=null)
                        {
                            costedCons = costingInfo.FabricConsumptionPerDzn.Value;
                        }
                        planMaster.CostedCons = costedCons;///check
                        rResult = await markerCuttingPlanMaster_ExcelRepository.MarkerCuttingPlanMaster_ExcelSave(planMaster);
                        /*
                    }
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "Data found in cutting, Excel upload denied";
                }
                */


            }
            catch (Exception e)
            {
                logger.LogInformation($"{e.Message} Row:{_sl}");
                throw new Exception(ReturnMessage.ErrorMessage);
            }
            return rResult;
        }

        private async Task<bool> CheckIfDataExistsInLotCutting(string orderNo, string color,int QuantityWithPetit)
        {
            try
            {
                return await lotWiseCuttingInfoService.CheckIfDataExistsInLotCutting(orderNo, color);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
