using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
   public  interface IExportInvoiceAdjustMasterRepository :IGenericRepository<ExportInvoiceAdjustMaster>
    {
        Task<RResult> SaveExportInfoiceAdjustment(ExportInvoiceAdjustMaster model);
        Task<RResult> GenerateAdjustNumber(int CompanyID);
        Task<List<ExportInvoiceAdjustmentListViewModel>> GetExportInvoiceAdjustmentList(ExportInvoiceAdjustmentListViewModel model);
    }
}
