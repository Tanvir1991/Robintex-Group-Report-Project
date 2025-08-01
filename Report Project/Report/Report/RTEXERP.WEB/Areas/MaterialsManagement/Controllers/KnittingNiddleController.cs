using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    public class KnittingNiddleController : BaseController
    {
        private readonly ICompanyInfoService companyInfoService;
        private readonly ITbl_KnittingMachinesService tbl_KnittingMachinesService;
        private readonly ICMBL_ItemAttributeService cMBL_ItemAttributeService;
        private readonly IDropdownService dropdownService;
        private readonly ICMBL_StockTransactionService cMBL_StockTransactionService;
        private readonly IKnittingNeedleConsumptionMasterService knittingNeedleConsumptionMasterService;
        private readonly IKnittingRepairItemCategoryService knittingRepairItemCategoryService;
        private readonly IUser_SetupService user_SetupService;
        public KnittingNiddleController(ICompanyInfoService _companyInfoService
            , ITbl_KnittingMachinesService _tbl_KnittingMachinesService,
            ICMBL_ItemAttributeService _cMBL_ItemAttributeService,
            IDropdownService _dropdownService,
            ICMBL_StockTransactionService _cMBL_StockTransactionService,
            IKnittingNeedleConsumptionMasterService _knittingNeedleConsumptionMasterService,
            IKnittingRepairItemCategoryService _knittingRepairItemCategoryService,
            IUser_SetupService _user_SetupService)
        {
            companyInfoService = _companyInfoService;
            tbl_KnittingMachinesService = _tbl_KnittingMachinesService;
            cMBL_ItemAttributeService = _cMBL_ItemAttributeService;
            dropdownService = _dropdownService;
            cMBL_StockTransactionService = _cMBL_StockTransactionService;
            knittingNeedleConsumptionMasterService = _knittingNeedleConsumptionMasterService;
            knittingRepairItemCategoryService = _knittingRepairItemCategoryService;
            user_SetupService = _user_SetupService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateKnittingNeedle()
        {
            var model = new KnittingNeedleConsumptionMasterViewModel();
            var companyList = await companyInfoService.GetDDLCompanyInfo();
            //  model.CompanyList = dropdownService.RenderDDL( await companyInfoService.GetDDLCompanyInfo(),true);
            model.CompanyList = dropdownService.RenderDDL(companyList.Where(b => b.Value == "183" || b.Value == "20183").ToList(), true);
            model.ItemCategoryList = await knittingRepairItemCategoryService.GetDDLKnittingRepairItemCategory();
            var machineData = await tbl_KnittingMachinesService.DDLMachine(0,true);
            model.MachineNoList = dropdownService.RenderDDL(machineData);//dropdownService.DefaultDDL();
            model.BroadGroupOneList = dropdownService.DefaultDDL();
            model.BroadGroupTwoList = dropdownService.DefaultDDL();
            model.BroadGroupThreeList = dropdownService.DefaultDDL();
            model.ItemList = dropdownService.DefaultDDL();
            model.IsEdit = false;
            model.CreateDateTime = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKnittingNeedle(KnittingNeedleConsumptionMasterViewModel knittingNeedleConsumption)
        {
            knittingNeedleConsumption.CreatedBy = Session_USER_ID;
            var machineInfo = await tbl_KnittingMachinesService.GetMachineInfo(knittingNeedleConsumption.MachineNo);
            if(machineInfo != null)
            {
                knittingNeedleConsumption.CompanyID = (int)machineInfo.CompanyID;
            }
            var rResult = await knittingNeedleConsumptionMasterService.SaveKnittingNeedleConsumptionData(knittingNeedleConsumption);
            return Json(rResult);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new KnittingNiddleViewModel();
            //model.KnittingNeedleConsumption = await knittingNeedleConsumptionMasterService.GetNittingNeedleConsuptionByCompanyIDAndMachineNo(DateTime.Now, DateTime.Now,0, 0);//await knittingNeedleConsumptionMasterService.GetNittingNeedleConsumptionList();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            var companyList = await companyInfoService.GetDDLCompanyInfo();
            model.CompanyList = dropdownService.RenderDDL(companyList.Where(b => b.Value == "183" || b.Value == "20183").ToList(), true);
            model.MachineNoList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> EditKnittingNeedle(int ID)
        {
            var model = new KnittingNeedleConsumptionMasterViewModel();
            model = await knittingNeedleConsumptionMasterService.GetKnittingNeedleConsumptionMasterData(ID);
            var companyList = await companyInfoService.GetDDLCompanyInfo();
            model.CompanyList = dropdownService.RenderDDL(companyList.Where(b=>b.Value=="183"||b.Value== "20183").ToList(),true);

            model.ItemCategoryList = await knittingRepairItemCategoryService.GetDDLKnittingRepairItemCategory();
           
            model.MachineNoList = dropdownService.RenderDDL(await tbl_KnittingMachinesService.DDLMachine(model.CompanyID),true);
            model.BroadGroupOneList = dropdownService.RenderDDL(await cMBL_ItemAttributeService.GetDDLCMBLItemAttributeBroadGroupOne(model.CompanyID, 1076),true);
            model.BroadGroupTwoList = dropdownService.DefaultDDL();
            model.BroadGroupThreeList = dropdownService.DefaultDDL();
            model.ItemList = dropdownService.DefaultDDL();
            model.IsEdit = true;
            return View("CreateKnittingNeedle", model);
        }

        public async Task<IActionResult> KnittingNeedleReportPage(DateTime DateFrom, DateTime DateTo, int CompanyId, int MachineNo , string ReportFormat)
        {
            string reportName = "KnittingMachineReparingCost";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));
            parameters.Add("MachineID", MachineNo);
            parameters.Add("CompanyID", CompanyId);
            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }


        #region Action Json
        public async Task<IActionResult> GetKnittingNeedleMasterDataByCompanyIDAndMachineNo(DateTime dateFrom, DateTime dateTo, int companyId, int machineNo)
        {
            var listOfObj = await knittingNeedleConsumptionMasterService.GetNittingNeedleConsuptionByCompanyIDAndMachineNo(dateFrom, dateTo, companyId, machineNo);
            return Json(listOfObj);
        }
        public async Task<IActionResult> GetCompanyWiseMachineNo(int companyID)
        {
            var listofObj = await tbl_KnittingMachinesService.DDLMachine(companyID);
            var list = dropdownService.RenderDDL(listofObj.Where(b => b.Value != "0").ToList(), true);
            // var list = dropdownService.RenderDDL(await tbl_KnittingMachinesService.DDLMachine(companyID), true);
            return Json(list);
        }
        public async Task<IActionResult> GetBroadGroupOne(int companyID)
        {
            int userID = 1076;
            if (companyID == 20183)
            {
                userID = 1083;
            }

            var list = dropdownService.RenderDDL(await cMBL_ItemAttributeService.GetDDLCMBLItemAttributeBroadGroupOne(companyID, userID), true);//userId=1076
            return Json(list);
        }
        public async Task<IActionResult> GetBroadGroupTwoList(int parentAttributeId)
        {
            var list = dropdownService.RenderDDL(await cMBL_ItemAttributeService.GetDDLCMBLItemAttributeBroadGroupTwo(parentAttributeId, 2), true);
            return Json(list);
        }
        public async Task<IActionResult> GetBroadGroupThreeList(int parentAttributeId)
        {
            var list = dropdownService.RenderDDL(await cMBL_ItemAttributeService.GetDDLCMBLItemAttributeBroadGroupThree(parentAttributeId, 3), true);
            return Json(list);
        }
        public async Task<IActionResult> GetBroadGroupItemList(int parentAttributeId)
        {
            var list = dropdownService.RenderDDL(await cMBL_ItemAttributeService.GetDDLCMBLItemAttributeByParentID(parentAttributeId), true);
            return Json(list);
        }
        public async Task<IActionResult> GetDocumentTypeWiseRate(int itemid)
        {
            var rate = await cMBL_StockTransactionService.GetDocumentTypeWiseRate(itemid);
            return Json(rate);
        }
        #endregion  Action Json

    }
}
