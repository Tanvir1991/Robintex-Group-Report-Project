using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class OrderColorWiseRejectionBreakdown_ReportRepository:GenericRepository<OrderColorWiseRejectionBreakdown_Report>, IOrderColorWiseRejectionBreakdown_ReportRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public OrderColorWiseRejectionBreakdown_ReportRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> OrderColorWiseRejectionBreakdown_ReportSave(List<OrderColorWiseRejectionBreakdown_Report> entity)
        {
            RResult rResult = new RResult();
            try
            {
                var entityList = new List<OrderColorWiseRejectionBreakdown_Report>();
                foreach (var item in entity)
                {
                    if (item.BreakdownID > 0)
                    {
                        var dbEntity = dbCon.OrderColorWiseRejectionBreakdown_Report.Where(x => x.BreakdownID == item.BreakdownID).First();
                        dbEntity.TotalDefectQty = item.TotalDefectQty;
                    }
                    else
                    {
                        dbCon.OrderColorWiseRejectionBreakdown_Report.Add(item);
                    }
                }
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
