using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
    public interface IShippingInvoiceExcelMigrationService
    {
        Task<List<ShippingInvoiceExcelMigrationViewModel>> ShippingInvoiceSave(ExcelPackage package);
    }
}
