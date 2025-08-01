using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IMarkerCuttingSizes_ExcelRepository:IGenericRepository<MarkerCuttingSizes_Excel>
    {
        Task<List<OrderWiseMarkerInfoViewModel>> GetMarkerCuttingSizesExcel_ByOrder(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID);
        Task<List<MarkerSizeInfoViewModel>> GetMarkerShortCuttingSizesExcel_ByOrder(string orderNo, string pantoneNo, int quantity);
    }
}
