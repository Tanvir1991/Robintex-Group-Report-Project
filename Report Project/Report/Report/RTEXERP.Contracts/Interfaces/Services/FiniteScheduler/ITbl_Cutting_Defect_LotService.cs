using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface ITbl_Cutting_Defect_LotService
    {
        Task<RResult> SaveCutting_Defect_Lot(Tbl_Cutting_Defect_Lot entity);
        Task<RResult> RemoveCutting_Defect_Lot(int id, int? removedBy=0);
        Task<List<Tbl_Cutting_Defect_LotViewModel>> GetDefectLotList(DateTime? dateFrom, DateTime? dateTo);
    }
}
