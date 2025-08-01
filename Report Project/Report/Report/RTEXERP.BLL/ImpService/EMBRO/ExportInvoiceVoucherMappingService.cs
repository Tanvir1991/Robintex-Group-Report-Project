using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class ExportInvoiceVoucherMappingService : IExportInvoiceVoucherMappingService
    {
        public readonly IExportInvoiceVoucherMappingRepository exportInvoiceVoucherMappingRepository;
        public ExportInvoiceVoucherMappingService(IExportInvoiceVoucherMappingRepository exportInvoiceVoucherMappingRepository)
        {
            this.exportInvoiceVoucherMappingRepository = exportInvoiceVoucherMappingRepository;

        }
        public async Task<string> AutoExportInvoiceVoucherMappingNo(int ExportInvoiceTypeID, DateTime voucherDate)
        {
            return await exportInvoiceVoucherMappingRepository.AutoExportInvoiceVoucherMappingNo(ExportInvoiceTypeID, voucherDate);
        }

        public async Task<List<SelectListItem>> DDLExportVoucher(long CompanyID,int ExportTypeID)
        {
            return await exportInvoiceVoucherMappingRepository.DDLExportVoucher(CompanyID,ExportTypeID);
        }

        public async Task<RResult> SaveExportInvoiceVoucherMapping(ExportInvoiceVoucherMapping model, bool? saveChange = true)
        {
            return await exportInvoiceVoucherMappingRepository.SaveExportInvoiceVoucherMapping(model,saveChange);
        }
    }
}
