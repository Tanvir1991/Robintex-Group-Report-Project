using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
    public interface IExportInvoiceTypeService
    {
        Task<List<SelectListItem>> DDLExportInvoiceType();
    }
}
