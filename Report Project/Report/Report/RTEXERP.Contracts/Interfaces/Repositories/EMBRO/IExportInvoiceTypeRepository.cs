using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface IExportInvoiceTypeRepository : IGenericRepository<ExportInvoiceType>
    {
        Task<List<SelectListItem>> DDLExportInvoiceType();
    }
}
