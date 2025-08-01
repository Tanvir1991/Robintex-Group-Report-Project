using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface ICMBL_SampleRepository :IGenericRepository<CMBL_Sample>
    {
        Task<List<SelectListItem>> DDLSampleNo();
        Task<RResult> CMBL_SampleSave(CMBL_SampleViewModel model, int createdBy, bool saveChanges = true);
        Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemList(long CompanyId, long RequisitionNo);
        Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemListForGateReceiving(long sampleNo);
        
    }
}
