using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class Tbl_marker_short_cuttingService : ITbl_marker_short_cuttingService
    {
        private readonly ITbl_marker_short_cuttingRepository tbl_Marker_Short_CuttingRepository;
        public Tbl_marker_short_cuttingService(ITbl_marker_short_cuttingRepository _tbl_Marker_Short_CuttingRepository)
        {
            tbl_Marker_Short_CuttingRepository = _tbl_Marker_Short_CuttingRepository;
        }

        
        public async Task<CuttingProductionReportPageMasterViewModel> GetCuttingProductionReportData(DateTime dateFrom, DateTime dateTo)
        {
            var model = new CuttingProductionReportPageMasterViewModel();
            var cuttingSummery = await tbl_Marker_Short_CuttingRepository.GetCompanyWiseCuttingQty(dateFrom,dateTo);
            var cuttingDetail = await tbl_Marker_Short_CuttingRepository.GetCuttingProductionReportDetailData(dateFrom, dateTo);

            model.DateFrom = dateFrom.ToString("dd-MMM-yyyy");
            model.DateTo = dateTo.ToString("dd-MMM-yyyy");
            var cblCutting = cuttingSummery.Where(x => x.CompanyShortName == "cbl").ToList();
            var rblCutting = cuttingSummery.Where(x => x.CompanyShortName == "rbl").ToList();

            //model.CBLProductionQty = cblCutting.Count>0? cblCutting.First().CuttingQuantity:0;
            //model.RBLProductionQty = rblCutting.Count>0? rblCutting.First().CuttingQuantity:0;

            model.CBLCuttingQty = cblCutting.Count > 0 ? cblCutting.First().CuttingQuantity : 0;
            model.CBLInspectionQty = cblCutting.Count > 0 ? cblCutting.First().InspectionQuantity : 0;
            model.CBLPassQty = cblCutting.Count > 0 ? cblCutting.First().PassQuantity : 0;

            model.RBLCuttingQty = rblCutting.Count > 0 ? rblCutting.First().CuttingQuantity : 0;
            model.RBLInspectionQty = rblCutting.Count > 0 ? rblCutting.First().InspectionQuantity : 0;
            model.RBLPassQty= rblCutting.Count > 0 ? rblCutting.First().PassQuantity : 0;

            model.TotalCuttingQty = model.CBLCuttingQty + model.RBLCuttingQty;
            model.TotalInspectionQty = model.CBLInspectionQty+ model.RBLInspectionQty;
            model.TotalPassQty = model.CBLPassQty + model.RBLPassQty;
            //model.CostPerPiece = model.TotalProductionQty>0? model.TotalSalary / model.TotalInspectionQty : 0;

            model.CuttingProductionDetail = cuttingDetail;
            return model;
        }
        public async Task<List<CompanyWiseCuttingQtyViewModel>> GetDailyCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo)
        {
            return await tbl_Marker_Short_CuttingRepository.GetDailyCompanyWiseCuttingQty(dateFrom,dateTo);
        }
    }
}
