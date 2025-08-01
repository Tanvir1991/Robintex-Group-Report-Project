using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.CMS;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.CMS
{
    public class ProductionLineEmployeeRepository : GenericRepository<ProductionLineEmployee>, IProductionLineEmployeeRepository
    {
        private readonly   CMSDBContext _dbCon;
        public ProductionLineEmployeeRepository(CMSDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
  

        public async Task<List<ProductionLineEmployee>> GetProductionLineEmployee(DateTime SalaryDateFrom, DateTime SalaryDateTo, int SectionID = 0)
        {
            //var list = _dbCon.ProductionLineEmployee
            //    .Where(b => b.SalaryDate >= SalaryDateFrom && b.SalaryDate <= SalaryDateTo);
            //if (SectionID > 0)
            //{
            //    list = list.Where(b => b.SectionID == SectionID);
            //}
            //return await list.ToListAsync();
            var itemList = new List<ProductionLineEmployee>();
            try
            {
                await _dbCon.LoadStoredProc("ajt.USP_ProductionLineEmployee")
                             .WithSqlParam("SalaryDateFrom", SalaryDateFrom)
                             .WithSqlParam("SalaryDateTo", SalaryDateTo)
                              .WithSqlParam("SectionID", SectionID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<ProductionLineEmployee>() as List<ProductionLineEmployee>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
