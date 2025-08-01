using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Common;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class Tbl_cutting_defect_lotRepository : GenericRepository<Tbl_Cutting_Defect_Lot>, ITbl_cutting_defect_lotRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;

        public Tbl_cutting_defect_lotRepository(FiniteSchedulerDBContext _context)
            : base(_context)
        {
            dbCon = _context;
        }
        public async Task<List<Tbl_Cutting_Defect_LotViewModel>> GetDefectLotList(DateTime? dateFrom,DateTime? dateTo)
        {
            dateFrom = dateFrom == null ? DateTime.Now : dateFrom;
            dateTo = dateTo == null ? DateTime.Now : dateTo;

            var data = await (from dl in dbCon.Tbl_Cutting_Defect_Lot
                              join lmm in dbCon.DFS_LotMakingMaster on dl.LotID equals lmm.ID
                              where dl.IsActive ==true && dl.IsRemoved==false &&  dl.CreatedDate.Date >= dateFrom.Value.Date && dl.CreatedDate.Date <= dateTo.Value.Date
                              select new Tbl_Cutting_Defect_LotViewModel()
                              {
                                  ID = dl.ID,
                                  LotID = dl.LotID,
                                  LotNo = lmm.LotNo.Trim(),
                                  LotReceivedKG = dl.LotReceivedKG,
                                  CreatedDateMsg = dl.CreatedDate.ToString("dd-MMM-yyyy"),
                                  ChallanNo=dl.ChallanNo
                              }).ToListAsync();
            return data;

        }

        public async Task<RResult> RemoveCutting_Defect_Lot(int id, int? removedBy=0)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await GetByIdAsync(id);
                entity.IsRemoved = true;
                entity.UpdatedBy = removedBy;
                entity.UpdatedDate = DateTime.Now;
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }

        public async Task<RResult> SaveCutting_Defect_Lot(Tbl_Cutting_Defect_Lot entity)
        {
            RResult rResult = new RResult();
            try
            {
                if (entity.ID>0)
                {
                    var dbEntity = await GetByIdAsync(entity.ID);
                    dbEntity.LotID = entity.LotID;
                    dbEntity.LotReceivedKG = entity.LotReceivedKG;
                    dbEntity.UpdatedBy = entity.CreatedBy;
                    dbEntity.UpdatedDate = DateTime.Now;
                }
                else
                {
                    entity.IsActive = true;
                    entity.IsRemoved = false;
                    entity.CreatedDate = DateTime.Now;
                    dbCon.Tbl_Cutting_Defect_Lot.Add(entity);
                } 
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }
    }
}
