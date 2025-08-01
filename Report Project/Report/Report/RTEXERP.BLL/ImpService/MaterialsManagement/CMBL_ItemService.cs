using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_ItemService: ICMBL_ItemService
    {
        private readonly ICMBL_ItemRepository cMBL_ItemRepository;
        public CMBL_ItemService(ICMBL_ItemRepository cMBL_ItemRepository)
        {
            this.cMBL_ItemRepository = cMBL_ItemRepository;
        }
    }
}
