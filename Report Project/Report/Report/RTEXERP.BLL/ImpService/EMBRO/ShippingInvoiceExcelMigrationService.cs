using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class ShippingInvoiceExcelMigrationService : IShippingInvoiceExcelMigrationService
    {
        private readonly IShippingInvoiceExcelMigrationRepository shippingInvoiceExcelMigrationRepository;
        public ShippingInvoiceExcelMigrationService(IShippingInvoiceExcelMigrationRepository shippingInvoiceExcelMigrationRepository)
        {
            this.shippingInvoiceExcelMigrationRepository = shippingInvoiceExcelMigrationRepository;
        }
        public async Task<List<ShippingInvoiceExcelMigrationViewModel>> ShippingInvoiceSave(ExcelPackage package)
        {
            return await shippingInvoiceExcelMigrationRepository.ShippingInvoiceSave(package);
        }
    }
}
