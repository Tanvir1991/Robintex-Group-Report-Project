using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using RTEXERP.WEB.Helper;

namespace RTEXERP.WEB.Controllers
{
    public class CuttingPlanController : BaseController
    {
        private readonly IMarkerCuttingPlanMaster_ExcelService markerCuttingPlanMaster_ExcelService;
        public CuttingPlanController(IMarkerCuttingPlanMaster_ExcelService markerCuttingPlanMaster_ExcelService)
        {
            this.markerCuttingPlanMaster_ExcelService = markerCuttingPlanMaster_ExcelService;
        }
        public IActionResult ExcelUpload ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ExcelUpload(List<IFormFile> files)
        {
            //RResult<ShippingInvoiceExcelMigrationViewModel> result = new RResult<ShippingInvoiceExcelMigrationViewModel>();
            var file = files[0];
            var fileName = file.FileName;
            var fileExtension = System.IO.Path.GetExtension(fileName);
            var fileSize = file.Length;
            ViewBag.result = "";
            MarkerCuttingPlanMaster_Excel excelData = new MarkerCuttingPlanMaster_Excel();
            if (file != null && fileSize <= 5242880)//max 5MB
            {
                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        using (var package = new ExcelPackage(stream))
                        {
                            var rResult = await markerCuttingPlanMaster_ExcelService.MarkerCuttingPlanMaster_ExcelSave(package,SessionData.Session_USER_ID);
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
            return View();

        }
    }
}
