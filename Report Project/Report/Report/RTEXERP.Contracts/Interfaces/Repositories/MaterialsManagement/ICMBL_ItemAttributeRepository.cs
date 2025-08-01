using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface ICMBL_ItemAttributeRepository:IGenericRepository<CMBL_ItemAttribute>
    {
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupOne(int companyID, int userId);
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroup(int parentAttributeID, int attributeLevel);
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeByParentID(int parentAttributeID);
    }
}
