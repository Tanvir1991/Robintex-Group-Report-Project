using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
    public interface IExportInvoiceAdjustMasterService
    {
        Task<RResult> SaveExportInfoiceAdjustment(ExportInvoiceAdjustMasterViewModel model);
       Task<RResult> GenerateAdjustNumber(int CompanyID);
        Task<List<ExportInvoiceAdjustmentListViewModel>> GetExportInvoiceAdjustmentList(ExportInvoiceAdjustmentListViewModel model);
    }
}
