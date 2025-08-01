using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.BLModels.EMS.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMS
{
   public interface IEM_PIM_PACKINGINVOICE_MASTERService
    {
        Task<List<ExportInvoiceForExportVoucher>> ExportInvoiceForExportVoucher(long CompanyID, DateTime InvoiceDate);
        Task<List<SelectListItem>> DDLExportInvoiceForExportVoucher(long CompanyID,DateTime InvoiceDate);
        Task<List<SelectListItem>> DDLInvoiceNumber(long CompanyID);

        Task<List<InvoiceOrderSPModel>> GetInvoiceOrder(int CompanyID,int InvoiceID);
 
    }
}
