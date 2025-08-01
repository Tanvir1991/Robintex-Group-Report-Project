
using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
   public interface IShippingInvoiceExcelMigrationRepository:IGenericRepository<ShippingInvoiceExcelMigration>
    {
        Task<List<ShippingInvoiceExcelMigrationViewModel>> ShippingInvoiceSave(ExcelPackage package);

    }
}
