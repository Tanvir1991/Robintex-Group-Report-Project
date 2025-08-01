using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface IMarkerCuttingSizes_ExcelService
    {
        Task<List<OrderWiseMarkerInfoViewModel>> GetMarkerCuttingSizesExcel_ByOrder(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID);
        Task<List<MarkerSizeInfoViewModel>> GetMarkerShortCuttingSizesExcel_ByOrder(string orderNo, string pantoneNo, int quantity);
    }
}
