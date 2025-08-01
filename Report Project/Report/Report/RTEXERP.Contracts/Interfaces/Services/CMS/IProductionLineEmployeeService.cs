using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.CMS
{
    public interface IProductionLineEmployeeService
    {
        Task<List<ProductionLineEmployee>> GetProductionLineEmployee(DateTime SalaryDateFrom, DateTime SalaryDateTo, int SectionID = 0);
    }
}
