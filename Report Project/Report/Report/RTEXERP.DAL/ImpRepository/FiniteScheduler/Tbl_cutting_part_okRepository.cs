using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class Tbl_cutting_part_okRepository : GenericRepository<Tbl_cutting_part_ok>, ITbl_cutting_part_okRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public Tbl_cutting_part_okRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLLotForCuttingDefect(int? LotUptoLast=3)
        {
            var data = await( from ok in dbCon.Tbl_cutting_part_ok
                       join lmm in dbCon.DFS_LotMakingMaster on ok.LotID equals lmm.ID
                       where ok.InspectionDate.Date >= DateTime.Now.AddMonths(-LotUptoLast.Value).Date
                       select new SelectListItem() { 
                       Text=lmm.LotNo.Trim(),
                       Value=lmm.ID.ToString()
                       }).Distinct().ToListAsync();
            return data;
        }
    }
}
