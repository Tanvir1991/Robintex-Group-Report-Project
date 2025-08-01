using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_UnitService : ICMBL_UnitService
    {
        private readonly ICMBL_UnitRepository cMBL_UnitRepository;
        public CMBL_UnitService(ICMBL_UnitRepository cMBL_UnitRepository)
        {
            this.cMBL_UnitRepository = cMBL_UnitRepository;
        }
        public async Task<List<SelectListItem>> DDLUnitListByCompany(long CompanyId)
        {
            return await cMBL_UnitRepository.DDLUnitListByCompany(CompanyId);
        }
    }
}
