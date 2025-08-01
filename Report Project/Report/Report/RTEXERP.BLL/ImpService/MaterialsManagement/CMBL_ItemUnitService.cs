using Microsoft.AspNetCore.Razor.Language;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_ItemUnitService: ICMBL_ItemUnitService
    {
        private readonly ICMBL_ItemUnitRepository CMBL_ItemUnitRepository;
        public CMBL_ItemUnitService(ICMBL_ItemUnitRepository CMBL_ItemUnitRepository)
        {
            this.CMBL_ItemUnitRepository = CMBL_ItemUnitRepository;
        }
    }
}
