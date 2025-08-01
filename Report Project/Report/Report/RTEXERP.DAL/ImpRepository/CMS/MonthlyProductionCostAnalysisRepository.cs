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
  public  class MonthlyProductionCostAnalysisRepository:GenericRepository<MonthlyProductionCostAnalysisMaster>, IMonthlyProductionCostAnalysisRepository
    {
        private CMSDBContext dbCon;

        public MonthlyProductionCostAnalysisRepository(CMSDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<RResult> SaveMonthWiseProduction(MonthlyProductionCostAnalysisMaster model)
        {
            try
            {
                var rResult = new RResult();
                if (model.ID>0)
                {
                     dbCon.MonthlyProductionCostAnalysisMaster.Update(model);
                    await dbCon.SaveChangesAsync();
                }
                else
                {
                    await dbCon.MonthlyProductionCostAnalysisMaster.AddAsync(model);
                    await dbCon.SaveChangesAsync();
                }
               
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                return rResult;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }

        public async Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetMonthlyProductionCostAnalysisList(int month,int yearID)
        {
            var list = await (from pm in dbCon.MonthlyProductionCostAnalysisMaster
                              join pmd in dbCon.MonthlyProductionCostAnalysisDetails on pm.ID equals pmd.MasterID
                              where pm.IsRemoved == false && pm.MonthID == month && pm.YearID == yearID && pmd.IsRemoved == false
                              select new MonthlyProductionCostAnalysisDetailsVM()
                              {
                                  ID=pmd.ID,
                                  MasterID=pmd.MasterID,
                                  ReportName=pmd.ReportName,
                                  Earning=pmd.Earning,
                                  SalaryCost=pmd.SalaryCost,
                              }).ToListAsync();
            return list;

        }

        public async Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetYearlyWiseProductionCostAnalysisList(int yearID)
        {
            var list = await(from pm in dbCon.MonthlyProductionCostAnalysisMaster
                             join pmd in dbCon.MonthlyProductionCostAnalysisDetails on pm.ID equals pmd.MasterID
                             where pm.IsRemoved == false  && pm.YearID == yearID && pmd.IsRemoved == false
                             select new MonthlyProductionCostAnalysisDetailsVM()
                             {
                                 YearID=pm.YearID,
                                 ID = pmd.ID,
                                 MasterID = pmd.MasterID,
                                 ReportName = pmd.ReportName,
                                 Earning = pmd.Earning,
                                 SalaryCost = pmd.SalaryCost,
                             }).ToListAsync();
            return list;
        }
        //public async Task<List<SalaryAnalysisDataPageViewModel>> GetMonthWiseProductionCostAnalysisList(int monthID, int yearID)
        //{
        //    var list = await (from pm in dbCon.MonthlyProductionCostAnalysisMaster
        //                      join pmd in dbCon.MonthlyProductionCostAnalysisDetails on pm.ID equals pmd.MasterID
        //                      where pm.IsRemoved == false && pm.MonthID == monthID && pm.YearID == yearID && pmd.IsRemoved == false
        //                      select new SalaryAnalysisDataPageViewModel()
        //                      {
        //                          MasterID = pmd.MasterID,
        //                          ReportName = pmd.ReportName,
        //                          Earning = pmd.Earning,
        //                          SalaryCost = pmd.SalaryCost,
        //                      }).ToListAsync();
        //    return list;

        //}
    }
}
