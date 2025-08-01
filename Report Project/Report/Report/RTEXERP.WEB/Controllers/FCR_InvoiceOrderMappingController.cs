using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Common.AccDefaultSetups;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.DBEntities.EMS;

namespace RTEXERP.WEB.Controllers
{
    public class FCR_InvoiceOrderMappingController : BaseController
    {
        private readonly IFCR_InvoiceOrderMappingService fCR_InvoiceOrderMappingService;
        private readonly IDropdownService dropdownService;
        private readonly IBasicCOAService basicCOAService;
        private readonly IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService;

        public FCR_InvoiceOrderMappingController(IDropdownService dropdownService
            , IFCR_InvoiceOrderMappingService fCR_InvoiceOrderMappingService
            , IBasicCOAService basicCOAService
            , IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService)
        {            
            this.dropdownService = dropdownService;
            this.basicCOAService = basicCOAService;
            this.fCR_InvoiceOrderMappingService = fCR_InvoiceOrderMappingService;
            this.em_PIM_PACKINGINVOICE_MASTERService = em_PIM_PACKINGINVOICE_MASTERService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new FCR_InvoiceOrderMappingViewModel();
            model.DDLCompany= await basicCOAService.DDLChartOfAccounts(null, 1);
            model.InvoiceList = dropdownService.DefaultDDL();
                //.RenderDDL(await em_PIM_PACKINGINVOICE_MASTERService.DDLInvoiceNumber(Session_COMPANY_ID),true);
            return View(model);
        }
        public async Task<JsonResult> GetFCR_InvoiceOrderMappingDetail(int InvoiceID)
        {
            var list = await fCR_InvoiceOrderMappingService.FCR_InvoiceOrderMappingDetail(InvoiceID);
            return Json(list);
        }
        [HttpPost]
        public async Task<JsonResult> FCR_InvoiceOrderMappingSave(List<FCR_InvoiceOrderMapping> entity)
        {
            var rResult = await fCR_InvoiceOrderMappingService.FCR_InvoiceOrderMappingSave(entity,true);
            return Json(rResult);
        }
        public async Task<JsonResult> InvoiceOrderFCRDataValidation(string ExcelData, int CompanyID)
        {
            RResult<FCR_InvoiceOrderMappingViewModel> rModel = new RResult<FCR_InvoiceOrderMappingViewModel>();
            List<FCR_InvoiceOrderMappingViewModel> dataModel = new List<FCR_InvoiceOrderMappingViewModel>();           
            try
            {
               
                var formExcelInformation = ExcelData.Trim();
                if (formExcelInformation.Length > 0)
                {
                    StringBuilder orderXMLsb = new StringBuilder();
                    orderXMLsb.Append("<OrderNoXML>");

                    int row = 1;
                    foreach (string rowData in formExcelInformation.Split('\n'))
                    {

                        if (!string.IsNullOrEmpty(rowData))
                        {
                           
                            var singleData = new FCR_InvoiceOrderMappingViewModel();

                            string[] column = rowData.Split('\t');
                            singleData.Sl = row;
                            singleData.InvoiceNo = column[0].ToString().Trim();
                            singleData.OrderNo = column[1].ToString().Trim();
                            singleData.FCRNo = column[2].ToString().Trim();
                            singleData.FCRDateMSG = column[3].ToString().Trim();  
                            dataModel.Add(singleData);
                            row += 1;
                            orderXMLsb.Append($"<OrderNos InvoiceNo=\"{singleData.InvoiceNo}\" OrderNo=\"{singleData.OrderNo}\" FCRNo=\"{singleData.FCRNo}\" FCRDateMSG=\"{singleData.FCRDateMSG}\"></OrderNos>");
                        }
                    }
                    orderXMLsb.Append("</OrderNoXML>");
                   
                    rModel.modelObjectList = await fCR_InvoiceOrderMappingService.InvoiceOrderFCRDataValidation(dataModel, orderXMLsb.ToString(), CompanyID);
                    //rModel.modelObjectList.ForEach(x => { x.Comment = (x.InvoiceID > 0 && x.OrderID > 0) == true ? "Valid" : "Invalid"; });
                    rModel.result = 1;

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
            
            //rModel.modelObjectList = dataModel;
            return Json(rModel);
        }

    }
}