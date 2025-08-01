using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
  public   interface IExportInvoiceVoucherMappingService
    {
        Task<RResult> SaveExportInvoiceVoucherMapping(ExportInvoiceVoucherMapping model, bool? saveChange = true);
        Task<string> AutoExportInvoiceVoucherMappingNo(int ExportInvoiceTypeID, DateTime voucherDate);
        Task<List<SelectListItem>> DDLExportVoucher(long CompanyID,int ExportTypeID);
    }
}
