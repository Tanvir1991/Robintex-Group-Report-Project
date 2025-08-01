using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherConfiguration;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Common.AccDefaultSetups;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using RTEXERP.DBEntities.Embro;
using RTEXERP.WEB.Extension;
using SSRSReport.Library;
using static RTEXERP.Contracts.Common.AccDefaultSetups.EmbroConstant;

namespace RTEXERP.WEB.Controllers
{
    public class BankPaymentVoucherController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly Itbl_Currency_SetupService currency_SetupService;
        private readonly IDropdownService dropdownService;
        private readonly ICBM_Instrument_TypeService cBM_Instrument_TypeService;
        private readonly IChequeSignatoryMasterService chequeSignatoryMasterService;
        private readonly Itbl_Currency_DetailService tbl_Currency_DetailService;
        private readonly IVoucherService voucherService;
        private readonly IExportInvoiceTypeService exportInvoiceTypeService;
        private readonly IExportInvoiceVoucherMappingService exportInvoiceVoucherMappingService;
        private readonly IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService;
        private readonly IExportInvoiceAdjustMasterService exportInvoiceAdjustMasterService;
        private readonly ICBM_BankService cBM_BankService;
        private readonly ICBM_BranchService cBM_BranchService;
        private readonly ICBM_BankAccountSetupServie cBM_BankAccountSetupServie;
        private readonly ICBM_ChequeService iCBM_ChequeService;
        private readonly IFCR_InvoiceOrderMappingService fCR_InvoiceOrderMappingService;
        public BankPaymentVoucherController(IBasicCOAService basicCOAService, Itbl_Currency_SetupService currency_SetupService, IDropdownService dropdownService
            , ICBM_Instrument_TypeService cBM_Instrument_TypeService, IChequeSignatoryMasterService chequeSignatoryMasterService, Itbl_Currency_DetailService tbl_Currency_DetailService
            , IVoucherService voucherService, IExportInvoiceTypeService exportInvoiceTypeService, IExportInvoiceVoucherMappingService exportInvoiceVoucherMappingService
            , IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService, IExportInvoiceAdjustMasterService exportInvoiceAdjustMasterService
            , ICBM_BankService cBM_BankService, ICBM_BranchService cBM_BranchService, ICBM_BankAccountSetupServie cBM_BankAccountSetupServie
            , ICBM_ChequeService iCBM_ChequeService, IFCR_InvoiceOrderMappingService fCR_InvoiceOrderMappingService)
        {
            this.basicCOAService = basicCOAService;
            this.currency_SetupService = currency_SetupService;
            this.dropdownService = dropdownService;
            this.cBM_Instrument_TypeService = cBM_Instrument_TypeService;
            this.chequeSignatoryMasterService = chequeSignatoryMasterService;
            this.tbl_Currency_DetailService = tbl_Currency_DetailService;
            this.voucherService = voucherService;
            this.exportInvoiceTypeService = exportInvoiceTypeService;
            this.exportInvoiceVoucherMappingService = exportInvoiceVoucherMappingService;
            this.em_PIM_PACKINGINVOICE_MASTERService = em_PIM_PACKINGINVOICE_MASTERService;
            this.exportInvoiceAdjustMasterService = exportInvoiceAdjustMasterService;
            this.cBM_BankService = cBM_BankService;
            this.cBM_BranchService = cBM_BranchService;
            this.cBM_BankAccountSetupServie = cBM_BankAccountSetupServie;
            this.iCBM_ChequeService = iCBM_ChequeService;
            this.fCR_InvoiceOrderMappingService = fCR_InvoiceOrderMappingService;
        }
        public async Task<IActionResult> Index(int CompanyId = 183)
        {
            try
            {
                var model = new BankPaymentVoucherViewModel();
                int DiscountAccID = 0;
                model.CompanyList = (await basicCOAService.DDLChartOfAccounts(null, 1)).Where(b => b.Value != "3684").ToList();
                var userInfo = await basicCOAService.GetACCUserCompany(User.Identity.Name.ToString());

                if (userInfo != null && userInfo.CompanyID > 0)
                {
                    model.CompanyID = (int)userInfo.CompanyID;

                    model.CompanyList.ForEach(b => { b.Disabled = (b.Value == model.CompanyID.ToString()) ? false : true; });
                }
                else
                {
                    model.CompanyID = CompanyId;
                }

                if (model.CompanyID == 183)
                {
                    model.BusinessID = 6;
                    DiscountAccID = 2553;
                }
                else
                {
                    model.BusinessID = 20006;
                    DiscountAccID = 21004;
                }


                model.BusinessList = await basicCOAService.DDLChartOfAccounts(model.CompanyID, AccLevel.Business);
                model.LocationList = await basicCOAService.DDLChartOfAccounts(model.CompanyID, AccLevel.Location);
                model.Date = DateTime.Now;
                model.CurrencyList = await currency_SetupService.DDLCurrencyList();
                model.CurrencyID = 15;
                model.ExchangeRate = 1;
                model.PaymentTypeList = VoucherPaymentType();
                model.ExportInvoiceTypeList = await exportInvoiceTypeService.DDLExportInvoiceType();
                model.CostCenterList = await basicCOAService.DDLChartOfAccounts(model.BusinessID, AccLevel.CostCenter);
                model.ActivityList = dropdownService.DefaultDDL(); //await basicCOAService.DDLChartOfAccounts(model.DebitCostCenterID, AccLevel.Activity);
                model.VATAccountList = await basicCOAService.DDLCompanyVatPayableAccount(model.CompanyID);
                model.ITaxAccountList = await basicCOAService.DDLCompanyAdvanceIncomeTaxAccount(model.CompanyID);
                var DiscountAcc = await basicCOAService.AccInfo(DiscountAccID);
                model.DiscountAccList = new List<SelectListItem>() {
                new SelectListItem{ Text=DiscountAcc.Description,Value=DiscountAcc.Id.ToString()}
            };
                model.InstrumentTypeList = await cBM_Instrument_TypeService.DDLCBM_Instrument_TypeList();
                model.SignatoryList = await chequeSignatoryMasterService.DDLChequeSignatoryMasterList(model.CompanyID);
                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private List<SelectListItem> VoucherPaymentType()
        {
            var paymentType = new List<SelectListItem>() {
                new SelectListItem{ Text="Direct Payment",Value="0"},
            new SelectListItem { Text = "Advance Payment Against Purchases", Value = "1" },
            new SelectListItem { Text = "Bill to Bill Payment", Value = "2" },
            new SelectListItem { Text = "Advance Payment Against Services", Value = "3" }

        };
            return paymentType;
        }

        public async Task<JsonResult> GetCurrencyRate(long CurrencyId)
        {
            var data = await tbl_Currency_DetailService.GetCurrencyRate(CurrencyId);
            return Json(data);
        }

        public async Task<JsonResult> GetVoucherAmount(long VoucherID)
        {
            var voucherDetail = await voucherService.GetVoucherdetailAsync(v => v.VoucherId == VoucherID && v.Amount > 0);
            var amount = voucherDetail.Sum(b => b.Amount);
            return Json(amount);
        }

        public async Task<JsonResult> GetLedgerBalance(int AccountId)
        {

            DateTime df = Convert.ToDateTime("2019-07-01");
            DateTime dt = Convert.ToDateTime("2020-06-30");
            var getLedgerBalance = await voucherService.GetLedgerBalence(AccountId, 2, df, dt);
            return Json(getLedgerBalance);
        }
        public async Task<JsonResult> GetBankAccountAutocompleite(string prefix)
        {
            var bankAccount = await basicCOAService.GetBankAccountAutocomplete(prefix, Session_COMPANY_ID);
            return Json(bankAccount);
        }
        [HttpPost]
        public async Task<JsonResult> SaveBankPaymentVoucher(List<VoucherViewModel> MasterVouchers, InstrumentViewModel InstrumentObj)
        {
            RResult rResult = new RResult();
            if (!ModelState.IsValid)
            {

                rResult.data = ModelState.AllErrors(); ;
                rResult.result = 2;
            }

            if (MasterVouchers != null)
            {
                MasterVouchers.ForEach(x =>
                {
                    x.PreparedBy = Session_EMPLOYEE_ID; x.PrepareDate = DateTime.Now;
                    x.Voucherdetail.ToList().ForEach(d => { d.Status = "50"; });
                });

                foreach (var voucher in MasterVouchers)
                {
                    voucher.PreparedBy = Session_EMPLOYEE_ID;
                    rResult = await voucherService.SaveBankPaymentVoucher(voucher, InstrumentObj, true);
                }

            }
            return Json(rResult);
        }

        public async Task<JsonResult> GSPExportInvoice(int CompanyID)
        {
            return Json(await em_PIM_PACKINGINVOICE_MASTERService.DDLExportInvoiceForExportVoucher(CompanyID, DateTime.Now));
        }
        public async Task<JsonResult> GSPExportInvoiceVoucher(int CompanyID,int ExportTypeID)
        {
            return Json(dropdownService.RenderDDL(await exportInvoiceVoucherMappingService.DDLExportVoucher(CompanyID, ExportTypeID), true));
        }
        public async Task<IActionResult> ExportInvoiceAdjustment(long CompanyID = 183)
        {
            ExportInvoiceAdjustMasterVMMapping model = new ExportInvoiceAdjustMasterVMMapping();
            model.DDLCompany = await basicCOAService.DDLChartOfAccounts(null, 1);
            var userInfo = await basicCOAService.GetACCUserCompany(User.Identity.Name.ToString());

            if (userInfo != null && userInfo.CompanyID > 0)
            {
                model.CompanyID = userInfo.CompanyID;
                model.CompanyName = userInfo.CompanyName;
                model.DDLCompany.ForEach(b => { b.Disabled = (b.Value == model.CompanyID.ToString()) ? false : true; });
            }
            else
            {
                model.CompanyID = CompanyID;
            }
            model.DDLExportService =await exportInvoiceTypeService.DDLExportInvoiceType();
            model.ExportServiceTypeID = 2;
            model.DDLVoucher = dropdownService.RenderDDL(await exportInvoiceVoucherMappingService.DDLExportVoucher(model.CompanyID,model.ExportServiceTypeID), true);
            model.DDLInvoice = await em_PIM_PACKINGINVOICE_MASTERService.DDLExportInvoiceForExportVoucher(model.CompanyID, DateTime.Now);
            return View(model);

        }
        [HttpPost]
        public async Task<JsonResult> SaveExportInfoiceAdjustment(ExportInvoiceAdjustMasterViewModel exportInvoiceAdjust)
        {

            RResult rResult = new RResult();
            try
            {
                if (!ModelState.IsValid)
                {
                    rResult.data = ModelState.AllErrors(); ;
                    rResult.result = 2;
                    return Json(rResult);
                }
                exportInvoiceAdjust.CreateBy = Session_EMPLOYEE_ID;
                rResult = await exportInvoiceAdjustMasterService.SaveExportInfoiceAdjustment(exportInvoiceAdjust);
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
            }
            return Json(rResult);

        }

        public async Task<IActionResult> ExportInvoiceAdjustmentList(long CompanyID = 183)
        {
            ExportInvoiceAdjustmentListViewModel model = new ExportInvoiceAdjustmentListViewModel();
            model.DDLCompany = await basicCOAService.DDLChartOfAccounts(null, 1);
            var userInfo = await basicCOAService.GetACCUserCompany(User.Identity.Name.ToString());
            model.DateFrom = DateTime.Now;
            model.DateTo = DateTime.Now;
            model.DDLExportInvoiceType = await exportInvoiceTypeService.DDLExportInvoiceType();
            if (userInfo != null && userInfo.CompanyID > 0)
            {
                model.CompanyID = userInfo.CompanyID;

                model.DDLCompany.ForEach(b => { b.Disabled = (b.Value == model.CompanyID.ToString()) ? false : true; });
            }
            else
            {
                model.CompanyID = CompanyID;
            }


            return View(model);
        }

        public async Task<JsonResult> GetExportInvoiceAdjustmentList(ExportInvoiceAdjustmentListViewModel model)
        {
            var adjList = await exportInvoiceAdjustMasterService.GetExportInvoiceAdjustmentList(model);
            return Json(adjList);
        }
        public async Task<IActionResult> GetExportInvoiceAdjustmentInfoReport(int AdjustmentID, int ExportInvoiceTypeID, string ReportFormat = "PDF")
        {
            string reportName = "FCRExportInvoiceAdjustmentInfoReport";
            if (ExportInvoiceTypeID == 1)
            {
                reportName = "GSPExportInvoiceAdjustmentInfoReport";
            }
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("AdjustmentID", AdjustmentID.ToString(""));
            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.EmbroConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<JsonResult> InvoiceDataValidation(string ExcelData, int CompanyID,int ExportServiceTypeID)
        {
            RResult<GSPInvoiceDataModel> rModel = new RResult<GSPInvoiceDataModel>();
            List<GSPInvoiceDataModel> dataModel = new List<GSPInvoiceDataModel>();
            bool dataIsOk = true;
            try
            {
                //var dbInvoiceList = await em_PIM_PACKINGINVOICE_MASTERService.ExportInvoiceForExportVoucher(CompanyID, DateTime.Now);
                var formExcelInformation = ExcelData.Trim();
                if (formExcelInformation.Length > 0)
                {
                    int row = 1;
                    StringBuilder orderXMLsb = new StringBuilder();
                    orderXMLsb.Append("<InvoiceOrderXml>");
                    foreach (string rowData in formExcelInformation.Split('\n'))
                    {

                        if (!string.IsNullOrEmpty(rowData))
                        {

                            var singleData = new GSPInvoiceDataModel();
                            string[] column = rowData.Split('\t');
                            singleData.Sl = row;
                            singleData.InvoiceNo = column[0].ToString().Trim();
                            singleData.OrderNo = column[1].ToString().Trim();
                            singleData.InvoiceAmount = Convert.ToDecimal(column[2].ToString());
                            string singleXml = "";
                            singleXml = $"<OrderNos InvoiceNo=\"{singleData.InvoiceNo.Replace("&", "&amp;")}\" OrderNo=\"{singleData.OrderNo}\" InvoiceAmount=\"{singleData.InvoiceAmount}\"></OrderNos>";
                            orderXMLsb.Append(singleXml);
                        }
                    }
                    orderXMLsb.Append("</InvoiceOrderXml>");
                    dataModel = await this.fCR_InvoiceOrderMappingService.InvoiceOrderMappingValidation(orderXMLsb.ToString(), CompanyID,ExportServiceTypeID);
                    //dataModel.ForEach(b => { b.Sl = row++; });
                    rModel.result = 1;
                    int errorCount = dataModel.Where(b => b.Status != "Valid").Count();
                    if (errorCount > 0)
                    {
                        dataIsOk = false;
                        rModel.statusCode = 0;
                        rModel.message = "Invalid data found";
                    }
                }
                else
                {
                    rModel.result = 0;
                    rModel.message = "Data is not valid";
                }
            }
            catch (Exception e)
            {
                rModel.result = 0;
                rModel.message = "Data type is not match.";
            }
            if (dataIsOk)
            {
                rModel.statusCode = 1;
            }
            else
            {
                rModel.statusCode = 0;
            }
            rModel.modelObjectList = dataModel;
            return Json(rModel);
        }

        public async Task<IActionResult> CBMLetterHonourofCheques(int CompanyID)
        {
            BankChequeViewModel model = new BankChequeViewModel();
            var userInfo = await basicCOAService.GetACCUserCompany(User.Identity.Name.ToString());
            model.DDLCompany = await basicCOAService.DDLChartOfAccounts(null, 1);
            if (userInfo != null && userInfo.CompanyID > 0)
            {
                model.CompanyID = (int)userInfo.CompanyID;

                model.DDLCompany.ForEach(b => { b.Disabled = (b.Value == model.CompanyID.ToString()) ? false : true; });
            }
            else
            {
                model.CompanyID = CompanyID;
            }
            AccDefaultSetup accDefaultSetup = new AccDefaultSetup(model.CompanyID);
            model.DDLBank = await cBM_BankService.DDLBank(Convert.ToDecimal(model.CompanyID));
            if (model.DDLBank.Count() > 0)
            {
                model.BankID = Convert.ToInt32(model.DDLBank[0].Value);
            }
            model.DDLBranch = await cBM_BranchService.DDL_CBMBankBranch(Convert.ToDecimal(model.CompanyID), model.BankID);

            if (model.DDLBranch.Count > 0)
            {
                model.BranchID = Convert.ToInt32(model.DDLBranch[0].Value);
            }
            model.DDLBankChartOfAccounts = await cBM_BankAccountSetupServie.DDLBankAccount(Convert.ToDecimal(model.CompanyID), model.BranchID);
            model.DDLBankALTChartOfAccounts = await cBM_BankAccountSetupServie.DDLBankAccount(Convert.ToDecimal(model.CompanyID), model.BranchID);
            if (model.DDLBankChartOfAccounts.Count > 0)
            {
                model.AccountID = Convert.ToInt32(model.DDLBankChartOfAccounts[0].Value);
            }

            if (model.DDLBankChartOfAccounts.Count > 0)
            {
                model.AccountID = Convert.ToInt32(model.DDLBankChartOfAccounts[0].Value);
            }
            model.DDLCheque = await iCBM_ChequeService.DDLIssuedCheque(model.AccountID);
            model.DDLVoucherCategory = accDefaultSetup.DDLVoucherCategory();
            return View(model);

        }
        public async Task<IActionResult> CBMLetterHonourofChequesReport(string LetterXML, string ReportFormat = "PDF")
        {
            string reportName = "Bank_CBM_Letter_HonourofCheques";// "Bank_CBM_Letter_HonourofCheques";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("LetterXML", LetterXML);
            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.EmbroConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<IActionResult> VoucherReports(int CompanyID)
        {
            VoucherReportsViewModel model = new VoucherReportsViewModel();
            var userInfo = await basicCOAService.GetACCUserCompany(User.Identity.Name.ToString());
            model.CompanyList = await basicCOAService.DDLChartOfAccounts(null, 1);
            if (userInfo != null && userInfo.CompanyID > 0)
            {
                model.CompanyID = (int)userInfo.CompanyID;
                model.CompanyList.ForEach(b => { b.Disabled = (b.Value == model.CompanyID.ToString()) ? false : true; });
            }
            else
            {
                if (CompanyID == 0) { CompanyID = 183; }
                model.CompanyID = CompanyID;
            }
            AccDefaultSetup accDefaultSetup = new AccDefaultSetup(model.CompanyID);

            List<int> ids = new List<int>() { 1, 2, 3, 7, 10, 14, 15, 23, 27, 28, 29, 33 };
            model.VoucherTypeList = await voucherService.DDLVoucherTypeList(ids);
            model.VoucherTypeID = 2;
            model.Month = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            model.YearList = Enumerable.Range(0, 4).Select(i => new SelectListItem { Value = DateTime.Now.AddYears(-i).Year.ToString(), Text = DateTime.Now.AddYears(-i).Year.ToString() }).ToList();
            model.MonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.VoucherList = await voucherService.DDLVoucherNumberList(model.VoucherTypeID, model.CompanyID, model.Month, model.Year);
            model.DDLVoucherCategory = accDefaultSetup.DDLVoucherCategory();
            return View(model);
        }
        public async Task<IActionResult> ReportVoucherReports(string ConditionalXML, string ReportFormat = "PDF")
        {
            string reportName = "Voucher_BankPaymentVoucher";// "Bank_CBM_Letter_HonourofCheques";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("VoucherParm", ConditionalXML);
            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.EmbroConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
    }
}