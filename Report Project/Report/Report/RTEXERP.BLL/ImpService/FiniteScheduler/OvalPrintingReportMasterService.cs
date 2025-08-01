using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class OvalPrintingReportMasterService : IOvalPrintingReportMasterService
    {
        private readonly IOvalPrintingReportMasterRepository ovalPrintingReportMasterRepository;
        public OvalPrintingReportMasterService(IOvalPrintingReportMasterRepository ovalPrintingReportMasterRepository)
        {
            this.ovalPrintingReportMasterRepository = ovalPrintingReportMasterRepository;
        }

        public async Task<OvalPrintingReportMasterViewModel> GetOvalPrintingInformation(DateTime ReportDate, int ID = 0,DateTime? ReportDateTo=null)
        {
            if (ReportDateTo == null)
            {
                ReportDateTo = ReportDate;
            }
            return await ovalPrintingReportMasterRepository.GetOvalPrintingInformation(ReportDate, ID, ReportDateTo);
        }

        public async Task<RResult> OvalPrintingReportMasterSave(ExcelPackage package)
        {
            RResult rResult = new RResult();
            try
            {
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    var master = new OvalPrintingReportMasterViewModel();
                    var detail = new List<OvalPrintingReportDetailsViewModel>();

                    var rowCount = sheet.Dimension.Rows;
                    var columnCount = sheet.Dimension.Columns;
                    if (rowCount > 7 && columnCount == 17)
                    {
                        var a = sheet.Cells[2, 1].Value.ToString().Trim();

                        master.ReportDate = Convert.ToDateTime(sheet.Cells[2, 1].Value.ToString().Trim());
                        for (int row = 8; row <= rowCount; row++)
                        {
                           
                            var MachineCode = sheet.Cells[row, 1].Value;
                            var BuyerName = sheet.Cells[row, 2].Value;
                            if (BuyerName == null)
                            {
                                break;
                            }
                            var OrderNo = sheet.Cells[row, 3].Value.ToString().Trim();
                            var StyleName = sheet.Cells[row, 4].Value.ToString().Trim();
                            var Color = sheet.Cells[row, 5].Value.ToString().Trim();
                            var PrintItem = sheet.Cells[row, 6].Value.ToString().Trim();
                            var OrderQty = Convert.ToInt32(sheet.Cells[row, 7].Value.ToString().Trim());
                            var ProductionQty = Convert.ToInt32(sheet.Cells[row, 8].Value.ToString().Trim());
                            var PrintPricePerDozen = Convert.ToDouble(sheet.Cells[row, 9].Value.ToString().Trim());
                            var CostPerDozen = Convert.ToDouble(sheet.Cells[row, 10].Value.ToString().Trim());
                            var ProfitPerDozen = Convert.ToDouble(sheet.Cells[row, 11].Value.ToString().Trim());
                            var TotalPrice = Convert.ToDouble(sheet.Cells[row, 12].Value.ToString().Trim());
                            var TotalCost = Convert.ToDouble(sheet.Cells[row, 13].Value.ToString().Trim());
                            var TotalProfit = Convert.ToDouble(sheet.Cells[row, 14].Value.ToString().Trim());
                            var TotalPriceBDT = Convert.ToDouble(sheet.Cells[row, 15].Value.ToString().Trim());
                            var TotalCostBDT = Convert.ToDouble(sheet.Cells[row, 16].Value.ToString().Trim());
                            var TotalProfitBDT = Convert.ToDouble(sheet.Cells[row, 16].Value.ToString().Trim());

                            detail.Add(new OvalPrintingReportDetailsViewModel
                            {
                                MachineCode = sheet.Cells[row, 1].Value.ToString().Trim(),
                                BuyerName = sheet.Cells[row, 2].Value.ToString().Trim(),
                                OrderNo = sheet.Cells[row, 3].Value.ToString().Trim(),
                                StyleName = sheet.Cells[row, 4].Value.ToString().Trim(),
                                Color = sheet.Cells[row, 5].Value.ToString().Trim(),
                                PrintItem = sheet.Cells[row, 6].Value.ToString().Trim(),
                                OrderQty = Convert.ToInt32(sheet.Cells[row, 7].Value.ToString().Trim()),
                                ProductionQty = Convert.ToInt32(sheet.Cells[row, 8].Value.ToString().Trim()),
                                PrintPricePerDozen = Convert.ToDouble(sheet.Cells[row, 9].Value.ToString().Trim()),
                                CostPerDozen = Convert.ToDouble(sheet.Cells[row, 10].Value.ToString().Trim()),
                                ProfitPerDozen = Convert.ToDouble(sheet.Cells[row, 11].Value.ToString().Trim()),
                                TotalPrice = Convert.ToDouble(sheet.Cells[row, 12].Value.ToString().Trim()),
                                TotalCost = Convert.ToDouble(sheet.Cells[row, 13].Value.ToString().Trim()),
                                TotalProfit = Convert.ToDouble(sheet.Cells[row, 14].Value.ToString().Trim()),
                                TotalPriceBDT = Convert.ToDouble(sheet.Cells[row, 15].Value.ToString().Trim()),
                                TotalCostBDT = Convert.ToDouble(sheet.Cells[row, 16].Value.ToString().Trim()),
                                TotalProfitBDT = Convert.ToDouble(sheet.Cells[row, 17].Value.ToString().Trim())
                            });
                        }
                       master.OvalPrintingReportDetails = detail;
                       rResult = await ovalPrintingReportMasterRepository.OvalPrintingReportMasterSave(master);
                    }
                    break;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
