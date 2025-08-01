using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class MarkerCuttingSizes_ExcelService: IMarkerCuttingSizes_ExcelService
    {
        private readonly IMarkerCuttingSizes_ExcelRepository markerCuttingSizes_ExcelRepository;
        public MarkerCuttingSizes_ExcelService(IMarkerCuttingSizes_ExcelRepository markerCuttingSizes_ExcelRepository)
        {
            this.markerCuttingSizes_ExcelRepository = markerCuttingSizes_ExcelRepository;
        }

        public async Task<List<OrderWiseMarkerInfoViewModel>> GetMarkerCuttingSizesExcel_ByOrder(string orderNo, string color,int MarkerCuttingPlanMaster_ExcelID)
        {
            return await markerCuttingSizes_ExcelRepository.GetMarkerCuttingSizesExcel_ByOrder(orderNo,color, MarkerCuttingPlanMaster_ExcelID);
        }

        public async Task<List<MarkerSizeInfoViewModel>> GetMarkerShortCuttingSizesExcel_ByOrder(string orderNo, string pantoneNo, int quantity)
        {
            return await markerCuttingSizes_ExcelRepository.GetMarkerShortCuttingSizesExcel_ByOrder(orderNo,  pantoneNo,  quantity);
        }
    }
}
