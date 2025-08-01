using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface ICMBL_SampleService
    {
        Task<List<SelectListItem>> DDLSampleNo();
        Task<RResult> CMBL_SampleSave(CMBL_SampleViewModel model, int createdBy, bool saveChanges = true);
        Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemList(long CompanyId, long RequisitionNo);
        Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemListForGateReceiving(long sampleNo);
        
    }
}
