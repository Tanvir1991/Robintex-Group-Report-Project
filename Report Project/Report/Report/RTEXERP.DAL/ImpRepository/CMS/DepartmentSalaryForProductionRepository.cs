using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.CMS
{
    public class DepartmentSalaryForProductionRepository : GenericRepository<DepartmentSalaryForProduction>, IDepartmentSalaryForProductionRepository
    {
        private CMSDBContext dbCon;
        public DepartmentSalaryForProductionRepository(CMSDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, DateTime SalaryDateFrom, DateTime SalaryDateTo)
        {
            var list = await dbCon.DepartmentSalaryForProduction.Where(b => b.IsRemoved == false
                                && b.ReportName == ReportName
                                && (b.SalaryDate >= SalaryDateFrom && b.SalaryDate <= SalaryDateTo))
                .Select(s => new ProductionReportSalaryViewModel
                {
                    SalaryDate = s.SalaryDate,
                    ReportName = s.ReportName,
                    Salary = s.SalaryCost==null?0:s.SalaryCost.Value,
                    OtherSalary = s.OtherCost == null ? 0 : s.OtherCost.Value,
                    OT = s.OTCost == null ? 0 : s.OTCost.Value,
                    OtherOT = s.OtherOTCost == null ? 0 : s.OtherOTCost.Value,
                    OverHeadCost = s.OverHeadCost == null ? 0 : s.OverHeadCost.Value,
                }).ToListAsync();
           
            return list;

        }

        public async Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, int Month,int Year)
        {
            var list = await dbCon.DepartmentSalaryForProduction.Where(b => b.IsRemoved == false
                               && b.ReportName == ReportName
                               && (b.SalaryDate.Month == Month && b.SalaryDate.Year == Year))
                             .Select(s => new ProductionReportSalaryViewModel
                             {
                                 SalaryDate = s.SalaryDate,
                                 ReportName = s.ReportName,
                                 Salary = s.SalaryCost == null ? 0 : s.SalaryCost.Value,
                                 OtherSalary = s.OtherCost == null ? 0 : s.OtherCost.Value,
                                 OT = s.OTCost == null ? 0 : s.OTCost.Value,
                                 OtherOT = s.OtherOTCost == null ? 0 : s.OtherOTCost.Value,
                                 OverHeadCost = s.OverHeadCost == null ? 0 : s.OverHeadCost.Value,
                             }).ToListAsync();
            return list;
        }
    }
}
