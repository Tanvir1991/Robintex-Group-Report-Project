using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface ICMBL_ItemAttributeService
    {
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupOne(int companyID, int userId); //,int? attributeLevelID
      
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupTwo(int parentAttributeID, int attributeLevel);
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupThree(int parentAttributeID, int attributeLevel);
        Task<List<SelectListItem>> GetDDLCMBLItemAttributeByParentID(int parentAttributeID);
    }
}
