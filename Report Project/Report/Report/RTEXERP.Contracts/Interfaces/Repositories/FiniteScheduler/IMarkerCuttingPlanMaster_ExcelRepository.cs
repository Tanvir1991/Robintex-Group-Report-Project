using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IMarkerCuttingPlanMaster_ExcelRepository:IGenericRepository<MarkerCuttingPlanMaster_Excel>
    {
        Task<RResult> MarkerCuttingPlanMaster_ExcelSave(MarkerCuttingPlanMaster_Excel excelData);
        Task<List<SelectListItem>> DDLOrderWiseMarker(string orderNo);
    
        Task<RResult> MarkerCuttingPlanMaster_ExcelRemove(string orderNo,string color);
        Task<List<SelectListItem>> DDLOrderWiseColor(string orderNo);
        //Task<RResult> LotWiseCuttingInfoUpdate(MarkerCuttingPlanMaster_Excel cuttingPlanMaster);
        Task<List<DropDownItem>> DDLOrderWiseColorCustome(string orderNo);
    }
}
