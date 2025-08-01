using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;

namespace RTEXERP.WEB.Controllers
{
    public class OvalPrintingReportController : BaseController
    {
        private readonly IOvalPrintingReportMasterService ovalPrintingReportMasterService;
        public OvalPrintingReportController(IOvalPrintingReportMasterService ovalPrintingReportMasterService)
        {
            this.ovalPrintingReportMasterService = ovalPrintingReportMasterService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new OvalPrintingReportMasterViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            RResult rResult = new RResult();
            try
            {
                var file = files[0];
                var fileName = file.FileName;
                var fileExtension = System.IO.Path.GetExtension(fileName);
                var fileSize = file.Length;
                ViewBag.result = "";
                //List<ShippingInvoiceExcelMigrationViewModel> returnList = new List<ShippingInvoiceExcelMigrationViewModel>();
                if (file != null && fileSize <= 5242880)//max 5MB
                {
                    if (fileExtension == ".xlsx" || fileExtension == ".xls")
                    {
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);

                            using (var package = new ExcelPackage(stream))
                            {

                                rResult = await ovalPrintingReportMasterService.OvalPrintingReportMasterSave(package);
                                if (rResult.result == 1)
                                {
                                    ViewBag.result = "Data uploaded successfully";
                                }
                                else
                                {
                                    ViewBag.result = "Error occured";
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewBag.result = "File Formet Not Matched.";
                    }
                }
                else
                {
                    ViewBag.result = "File Size Large Than 5 MB.";
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return RedirectToAction("OvalPrintingReportPage", "ALLReports", new { ReportDate = rResult.statusMsg, ID = rResult.statusCode });

        }
    }
}