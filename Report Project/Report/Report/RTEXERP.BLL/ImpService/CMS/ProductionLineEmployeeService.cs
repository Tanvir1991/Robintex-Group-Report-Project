using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.CMS
{
    public class ProductionLineEmployeeService : IProductionLineEmployeeService
    {
        private readonly IProductionLineEmployeeRepository _productionLineEmployeeRepository;

        public ProductionLineEmployeeService(IProductionLineEmployeeRepository productionLineEmployeeRepository)
        {
            _productionLineEmployeeRepository = productionLineEmployeeRepository;
        }
        public async Task<List<ProductionLineEmployee>> GetProductionLineEmployee(DateTime SalaryDateFrom, DateTime SalaryDateTo, int SectionID = 0)
        {
            return await _productionLineEmployeeRepository.GetProductionLineEmployee(SalaryDateFrom,SalaryDateTo,SectionID);
        }

         
    }
}
