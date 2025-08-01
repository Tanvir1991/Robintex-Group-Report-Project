using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.Embro;

namespace RTEXERP.WEB.Controllers
{
    public class SuplierInvoiceVoucherController:Controller
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly Itbl_Currency_SetupService itbl_Currency_SetupService;
        private readonly IVoucherService voucherService;
        public SuplierInvoiceVoucherController(IBasicCOAService basicCOAService, Itbl_Currency_SetupService itbl_Currency_SetupService
            , IVoucherService voucherService)
        {
            this.basicCOAService = basicCOAService;
            this.itbl_Currency_SetupService = itbl_Currency_SetupService;
            this.voucherService = voucherService;

        }
        public async Task<IActionResult> StampPaymentVoucher(int? CompanyID=183)
        {

            StampVoucherViewModel voucherModel = new StampVoucherViewModel();
            voucherModel.Vdate = DateTime.Now;
            voucherModel.CurrencyId = 15;
            voucherModel.DDLCompany = (await basicCOAService.DDLChartOfAccounts(null, 1)).Where(b=>b.Value!= "3684").ToList();
            voucherModel.DDLLocation = await basicCOAService.DDLChartOfAccounts(CompanyID, 3);
            voucherModel.DDLCurrencyList = await itbl_Currency_SetupService.DDLCurrencyList();
            return View(voucherModel);
        }
        public async Task<IActionResult> SaveStampVoucher(StampVoucherViewModel model)
        {
            RResult rResult = new RResult(); 
            if (ModelState.IsValid)
            {
                var data =await voucherService.AddStampVoucher(model);
                if (data.VoucherNumber != null)
                {
                    rResult.result = 1;
                    rResult.message = $"{data.VoucherNumber}-Successfully Created Voucher.";
                }
                else
                {
                    rResult.result = 0;
                    rResult.message ="Problem";
                }
                return Json(rResult);
            }
            rResult.result = 0;
            rResult.message = "Please Enter All Required Data.";
            return Json(rResult);
        }
    }
}