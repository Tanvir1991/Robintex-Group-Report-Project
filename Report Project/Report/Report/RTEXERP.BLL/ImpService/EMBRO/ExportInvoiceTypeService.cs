using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class ExportInvoiceTypeService : IExportInvoiceTypeService
    {
        private readonly IExportInvoiceTypeRepository exportInvoiceTypeRepository;
        public ExportInvoiceTypeService(IExportInvoiceTypeRepository exportInvoiceTypeRepository)
        {
            this.exportInvoiceTypeRepository = exportInvoiceTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLExportInvoiceType()
        {
            return await exportInvoiceTypeRepository.DDLExportInvoiceType();
        }
    }
}
