using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_ItemAttributeService : ICMBL_ItemAttributeService
    {
        private readonly ICMBL_ItemAttributeRepository cMBL_ItemAttributeRepository;

        public CMBL_ItemAttributeService(ICMBL_ItemAttributeRepository _cMBL_ItemAttributeRepository)
        {
            cMBL_ItemAttributeRepository = _cMBL_ItemAttributeRepository;
        }

        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupTwo(int parentAttributeID, int attributeLevel)
        {
            return await cMBL_ItemAttributeRepository.GetDDLCMBLItemAttributeBroadGroup(parentAttributeID, attributeLevel);
        }
        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupThree(int parentAttributeID, int attributeLevel)
        {
            return await cMBL_ItemAttributeRepository.GetDDLCMBLItemAttributeBroadGroup(parentAttributeID, attributeLevel);
        }

        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupOne(int companyID, int userId)
        {
            return await cMBL_ItemAttributeRepository.GetDDLCMBLItemAttributeBroadGroupOne(companyID, userId);
        }

        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeByParentID(int parentAttributeID)
        {
            return await cMBL_ItemAttributeRepository.GetDDLCMBLItemAttributeByParentID(parentAttributeID);
        }
    }
}
