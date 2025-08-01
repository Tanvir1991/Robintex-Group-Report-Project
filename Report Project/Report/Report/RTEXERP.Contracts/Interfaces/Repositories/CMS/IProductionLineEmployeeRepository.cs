using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.CMS
{
    public interface IProductionLineEmployeeRepository:IGenericRepository<ProductionLineEmployee>
    {
        Task<List<ProductionLineEmployee>> GetProductionLineEmployee(DateTime SalaryDateFrom,DateTime SalaryDateTo,int SectionID = 0);
    }
}
