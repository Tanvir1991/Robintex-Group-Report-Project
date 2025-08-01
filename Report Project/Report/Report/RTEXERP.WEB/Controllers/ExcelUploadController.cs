using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;

namespace RTEXERP.WEB.Controllers
{
    public class ExcelUploadController : BaseController
    {
        private readonly IShippingInvoiceExcelMigrationService shippingInvoiceExcelMigrationService;
        public ExcelUploadController(IShippingInvoiceExcelMigrationService shippingInvoiceExcelMigrationService)
        {
            this.shippingInvoiceExcelMigrationService = shippingInvoiceExcelMigrationService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            //RResult<ShippingInvoiceExcelMigrationViewModel> result = new RResult<ShippingInvoiceExcelMigrationViewModel>();
            var file = files[0];
            var fileName = file.FileName;
            var fileExtension = System.IO.Path.GetExtension(fileName);
            var fileSize = file.Length;
            ViewBag.result = "";
            List<ShippingInvoiceExcelMigrationViewModel> returnList = new List<ShippingInvoiceExcelMigrationViewModel>();
            if (file != null && fileSize <= 5242880)//max 5MB
            {
                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        using (var package = new ExcelPackage(stream))
                        {
                            returnList = await shippingInvoiceExcelMigrationService.ShippingInvoiceSave(package);
                            if (returnList.Count > 0)
                            {
                                ViewBag.result = "Duplicate Data Found";
                            }
                            else
                            {
                                ViewBag.result = "Success";
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


            
            return View(returnList);
            
        }
    }
}