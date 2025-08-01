using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RTEXERP.Common.DataInterChange;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using Snickler.EFCore;

namespace RTEXERP.WEB.Controllers
{
    [AllowAnonymous]
    public class CommonDropDownController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IUserAccessInfoService userAccessInfoService;
        private readonly IMaxcoDDLService maxcoDDLService;
        private readonly IBasicCOAService basicCOAService;
        private readonly Itbl_Currency_DetailService itbl_Currency_DetailService;
        private readonly ICBM_BankService cBM_BankService;
        private readonly ICBM_BranchService cBM_BranchService;
        private readonly ICBM_BankAccountSetupServie cBM_BankAccountSetupServie;
        private readonly ICBM_ChequeService iCBM_ChequeService;
        private readonly IVoucherService voucherService;
        private readonly IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService;
        private readonly IStyleService styleService;
        private readonly IFabricQuality_SetupService fabricQuality_SetupService;
        private readonly IExportInvoiceVoucherMappingService exportInvoiceVoucherMappingService;
        private readonly IPantoneService pantoneService;
        private readonly IMAC_OrderCostingInfoService mAC_OrderCostingInfoService;
        private readonly IDD_PurchaseOrderService ddPurchaseOrder;
        public CommonDropDownController(IDropdownService dropdownService, IUserAccessInfoService userAccessInfoService, IMaxcoDDLService maxcoDDLService
            , IBasicCOAService basicCOAService, Itbl_Currency_DetailService itbl_Currency_DetailService
            , ICBM_BankService cBM_BankService, ICBM_BranchService cBM_BranchService, ICBM_BankAccountSetupServie cBM_BankAccountSetupServie
            , ICBM_ChequeService iCBM_ChequeService    , IVoucherService voucherService
            , IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService
            , IStyleService styleService
            ,IFabricQuality_SetupService fabricQuality_SetupService
            , IExportInvoiceVoucherMappingService exportInvoiceVoucherMappingService
            ,IPantoneService pantoneService
            ,IMAC_OrderCostingInfoService mAC_OrderCostingInfoService
            , IDD_PurchaseOrderService _ddPurchaseOrder
            )
        {
            this.dropdownService = dropdownService;
            this.userAccessInfoService = userAccessInfoService;
            this.maxcoDDLService = maxcoDDLService;
            this.basicCOAService = basicCOAService;
            this.itbl_Currency_DetailService = itbl_Currency_DetailService;
            this.voucherService = voucherService;
            this.cBM_BankService = cBM_BankService;
            this.cBM_BranchService = cBM_BranchService;
            this.cBM_BankAccountSetupServie = cBM_BankAccountSetupServie;
            this.iCBM_ChequeService = iCBM_ChequeService;
            this.styleService = styleService;
            this.fabricQuality_SetupService = fabricQuality_SetupService;
            this.em_PIM_PACKINGINVOICE_MASTERService = em_PIM_PACKINGINVOICE_MASTERService;
            this.exportInvoiceVoucherMappingService = exportInvoiceVoucherMappingService;
            this.pantoneService = pantoneService;
            this.mAC_OrderCostingInfoService = mAC_OrderCostingInfoService;
            ddPurchaseOrder = _ddPurchaseOrder;
        }

        #region Basic
        
        //public JsonResult DDLGetCountryList()
        //{            
        //    return Json(dropdownService.RenderDDL(countryService.DDLGetCountryList()));
        //}
        //public JsonResult DDLGetDepartmentList()
        //{
        //    return Json(dropdownService.RenderDDL(departmentService.DDLGetDepartmentList(Session_COMPANY_ID)));
        //}
        //public JsonResult DDLGetDesignationList()
        //{
        //    return Json(dropdownService.RenderDDL(designationService.DDLGetDesignationList(Session_COMPANY_ID)));
        //}

        #endregion Basic


        #region ChartOFAccounts
        public JsonResult ddlCOACompany()
        {
            var companyList = userAccessInfoService.GetChantOfAccounts(0, 1)
                .Where(b => b.DESCRIPTION != "Robintex (Bangladesh) Limited (Garments Section)");

            var passList = companyList.Select(b => new SelectListItem()
            {
                Text = b.DESCRIPTION,
                Value = b.ID.ToString()
            }).ToList();

            var jsonObj = dropdownService.RenderDDL(passList);
            return Json(jsonObj);
        }

        public async Task<JsonResult> ddlBusiness(int CompanyId)
        {
            var businessList = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(CompanyId, 2), true);
            return Json(businessList);
        }

        public JsonResult ddlCostCenter(int CompanyId, int isDefault = 0)
        {
            int BusinessTypeId = 0;
            var finalOpject = new List<SelectListItem>();
            BusinessTypeId = new DataInterChangeMap().CompanyWiseDefaultBusinessType(CompanyId);

            var companyList = userAccessInfoService.GetChantOfAccounts(BusinessTypeId, 11)
                .Where(b => b.DESCRIPTION != "Not to Use");

            var passList = companyList.Select(b => new SelectListItem()
            {
                Text = b.DESCRIPTION,
                Value = b.ID.ToString()
            }).ToList();

            if (isDefault == 1)
            {
                finalOpject = dropdownService.RenderDDL(passList,true);
            }
            else
            {
                finalOpject = passList;
            }
            
            return Json(finalOpject);
        }

        public JsonResult ddlCOAAcctivity(int CostCenterId, int isDefault = 0)
        {
            var companyList = userAccessInfoService.GetChantOfAccounts(CostCenterId, 12);
            var finalOpject = new List<SelectListItem>();
            var passList = companyList.Select(b => new SelectListItem()
            {
                Text = b.DESCRIPTION,
                Value = b.ID.ToString()
            }).ToList();
            if (isDefault == 1)
            {
                finalOpject = dropdownService.RenderDDL(passList);
            }
            else
            {
                finalOpject = passList;
            }
            
            return Json(finalOpject);
        }
        public async Task<JsonResult> ddlAccCategory(int CompanyID)
        {
            var list = await basicCOAService.DDLChartOfAccounts(CompanyID, 4);
            var nList = dropdownService.RenderDDL(list, true);
            return Json(nList);
        }

        public async Task<JsonResult> ddlChartOfAccounts(int CompanyID,int LevelID,int isDefault=0)
        {
            var finalOpject = new List<SelectListItem>();
            var list = await basicCOAService.DDLChartOfAccounts(CompanyID, LevelID);
            if (isDefault == 1)
            {
                finalOpject = dropdownService.RenderDDL(list, true);
            }
            else
            {
                finalOpject = list;
            }
            
            return Json(finalOpject);
        }
        public async Task<JsonResult>  DDLCategoryChartOfAccounts(int CompanyID, int AccCategoryID)
        {
            var list = await basicCOAService.DDLCategoryChartOfAccounts(CompanyID,AccCategoryID);
            var nList = list;
            return Json(nList);
           
        }

        public async Task<JsonResult> DDLBank(decimal CompanyID)
        {
            var data = await this.cBM_BankService.DDLBank(CompanyID);
            return Json(data);
        }
        public async Task<JsonResult> DDLBankBranch(decimal CompanyID,int BankID)
        {
            var data = await this.cBM_BranchService.DDL_CBMBankBranch(CompanyID, BankID);
            return Json(data);
        }
        public async Task<JsonResult> DDLAccounts(decimal CompanyID,int BranchID)
        {
            var data = await this.cBM_BankAccountSetupServie.DDLBankAccount(CompanyID, BranchID);
            return Json(data);
        }
        public async Task<JsonResult> DDLBankCheque(  int BankAccountID)
        {
            var data = await this.iCBM_ChequeService.DDLIssuedCheque(BankAccountID);
            return Json(data);
        }
        #endregion

        #region EMS
        public async Task<JsonResult> getDDLInvoiceList(int CompanyID)
        {
            var nDDlist = await em_PIM_PACKINGINVOICE_MASTERService.DDLInvoiceNumber(CompanyID);
            var list = dropdownService.RenderDDL(nDDlist, true);
            return Json(list);
        }


        #endregion EMS
        #region EMBRO
        public async Task<JsonResult> GETDDLVoucher(int VoucherType, int CompanyId, int Month, int Year)
        {
            var list = dropdownService.RenderDDL(await voucherService.DDLVoucherNumberList(VoucherType, CompanyId, Month,Year),true);            
            return Json(list);
        }

        public async Task<JsonResult> DDLExportVoucherByExportType(long CompanyID,int ExportTypeID)
        {
            var list = await exportInvoiceVoucherMappingService.DDLExportVoucher(CompanyID, ExportTypeID);
            return Json(list);

        }
        #endregion EMBRO

        #region HRM

        //public JsonResult DDLGetCompanyList()
        //{
        //    return Json(dropdownService.RenderDDL(companyInfoService.DDLGetCompanyList()));
        //}

        #endregion HRM

        #region Lot

        #endregion
        #region YarnCount
        public async Task<JsonResult> GetFabricQuality(int FabricTypeID)
        {
            var nDDlist = await fabricQuality_SetupService.DDLFabricQuality(FabricTypeID);
             return Json(nDDlist);
        }
        public async Task<JsonResult> getDDLYarnCount(int CompositionId)
        {
            var nDDlist = await maxcoDDLService.DDLYarnCount(CompositionId);
            var list = dropdownService.RenderDDL(nDDlist, true);
            return Json(list);

        }

        public async Task<JsonResult> GetFabciComposition(string Composition)
        {
           
            try
            {
                var data =  await maxcoDDLService.GETFabricComposition(Composition);
                return Json(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<JsonResult> GetPantoneColor(string colorName)
        {

            try
            {
                var data = await pantoneService.GetPantoneColor( colorName, 20);
                return Json(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region CurrencyRate 
        public async Task<JsonResult> getCurrencyExchange(DateTime? CurrencyDate,int CurrencyID)
        {
            DateTime _CurrencyDate=DateTime.Now;
            if (CurrencyDate.HasValue == true)
            {
                _CurrencyDate = CurrencyDate.Value;
            }
         
            var currency = await itbl_Currency_DetailService.GetDateCurrencyRate(_CurrencyDate, CurrencyID);
            return Json(currency);
        }
        #endregion

        #region MAC

        public async Task<JsonResult> GetDirectAccessoriesItem(int? TrimID,string Search="")
        {
            var data = await mAC_OrderCostingInfoService.OrderDirectAccessoriesCostItem(TrimID, Search);
            return Json(data);
        }
        #endregion


        #region ViewComponent
        public ActionResult GetViewComponent(string viewName, string entity)
        {

            if (viewName == "YarnOnDateSummary")
            {
                var _data = JsonConvert.DeserializeObject(entity);
                var model = new DynamicObjectCast().ConvertDynamic<YarnStockModel>(_data);
                return ViewComponent(viewName, model);
            } else if (viewName == "OrderWiseItemStock") {
                var _data = JsonConvert.DeserializeObject(entity);
                var model = new DynamicObjectCast().ConvertDynamic<PurchaseOrderReport>(_data);
                return ViewComponent(viewName, model);
            } else if (viewName=="FinishFabricStock") {
                var _data = JsonConvert.DeserializeObject(entity);
                var model = new DynamicObjectCast().ConvertDynamic<FabricStockReport>(_data);
                return ViewComponent(viewName, model);
            }
            else if (viewName == "GreigeFabricStock")
            {
                var _data = JsonConvert.DeserializeObject(entity);
                var model = new DynamicObjectCast().ConvertDynamic<FabricStockReport>(_data);
                return ViewComponent(viewName, model);
            }
            
            return View("No Content Found");
        }
        public ActionResult GetViewComponents(string viewName, List<object> entity)
        {
            return ViewComponent(viewName, entity);
        }
        #endregion

        #region Style
        public async Task<JsonResult> DDLBuyerWiseOrder(int BuyerID,DateTime?DateFrom,DateTime? DateTo,string Predict=null)
        {
            var _DateFrom = DateFrom == null ?  new DateTime(2010,1,1) : DateFrom;
            var _DateTo = DateTo == null ? DateTime.Now : DateTo;
            var Orderlist =await styleService.DDLBuyerWiseOrder(BuyerID, _DateFrom, _DateTo,Predict);
            var returnOrderList = dropdownService.RenderDDL(Orderlist, true);
            return Json(returnOrderList);
        }
        public async Task<JsonResult> DDLOrderWiseStyle(int OrderID)
        {            
            var Orderlist = await styleService.DDLOrderWiseStyle(OrderID);
            var returnOrderList = dropdownService.RenderDDL(Orderlist, true);
            return Json(returnOrderList);
        }

        public async Task<JsonResult> DDLOrderWisePurchaseOrder(int OrderID, DateTime? DateFrom, DateTime? DateTo)
        {
            var _DateFrom = DateFrom == null ? new DateTime(2010, 1, 1) : DateFrom;
            var _DateTo = DateTo == null ? DateTime.Now : DateTo;
            var Orderlist = await ddPurchaseOrder.DDLPurchaseOrder(OrderID, _DateFrom, _DateTo);
            var returnOrderList = dropdownService.RenderDDL(Orderlist, true);
            return Json(returnOrderList);
        }
        #endregion
    }
}