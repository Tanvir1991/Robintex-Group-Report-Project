using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_DocumentType_SetupService: ICMBL_DocumentType_SetupService
    {
        private readonly ICMBL_DocumentType_SetupRepository CMBL_DocumentType_SetupRepository;
        public CMBL_DocumentType_SetupService(ICMBL_DocumentType_SetupRepository CMBL_DocumentType_SetupRepository)
        {
            this.CMBL_DocumentType_SetupRepository = CMBL_DocumentType_SetupRepository;
        }

    }
}
