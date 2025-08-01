using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class Tbl_Cutting_Defect_LotService : ITbl_Cutting_Defect_LotService
    {
        private readonly ITbl_cutting_defect_lotRepository tbl_Cutting_Defect_LotRepository;

        public Tbl_Cutting_Defect_LotService(ITbl_cutting_defect_lotRepository _tbl_Cutting_Defect_LotRepository)
        {
            tbl_Cutting_Defect_LotRepository = _tbl_Cutting_Defect_LotRepository;
        }
        public async Task<List<Tbl_Cutting_Defect_LotViewModel>> GetDefectLotList(DateTime? dateFrom, DateTime? dateTo)
        {
            return await tbl_Cutting_Defect_LotRepository.GetDefectLotList(dateFrom, dateTo);
        }

        public async Task<RResult> RemoveCutting_Defect_Lot(int id, int? removedBy=0)
        {
            return await tbl_Cutting_Defect_LotRepository.RemoveCutting_Defect_Lot(id, removedBy);
        }

        public async Task<RResult> SaveCutting_Defect_Lot(Tbl_Cutting_Defect_Lot entity)
        {
            return await tbl_Cutting_Defect_LotRepository.SaveCutting_Defect_Lot(entity);
        }
    }
}
