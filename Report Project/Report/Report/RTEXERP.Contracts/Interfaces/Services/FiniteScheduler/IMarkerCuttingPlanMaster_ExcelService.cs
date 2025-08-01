using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface IMarkerCuttingPlanMaster_ExcelService
    {
        Task<RResult> MarkerCuttingPlanMaster_ExcelSave(ExcelPackage package,int uploadedBy);
        Task<List<SelectListItem>> DDLOrderWiseMarker(string orderNo);
        Task<List<SelectListItem>> DDLOrderWiseColor(string orderNo);
        Task<List<DropDownItem>> DDLOrderWiseColorCustome(string orderNo);
        
        Task<RResult> LotWiseCuttingInfoUpdate(ConsumptionSheetUpdateViewModel updateModel);
    }
}
