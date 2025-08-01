using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_SampleService : ICMBL_SampleService
    {
        private readonly ICMBL_SampleRepository cmbl_SampleRepository;
        public CMBL_SampleService(ICMBL_SampleRepository cmbl_SampleRepository)
        {
            this.cmbl_SampleRepository = cmbl_SampleRepository;
        }
        public async Task<RResult> CMBL_SampleSave(CMBL_SampleViewModel model, int createdBy, bool saveChanges = true)
        {
            return await cmbl_SampleRepository.CMBL_SampleSave(model, createdBy, saveChanges);
        }

        public async Task<List<SelectListItem>> DDLSampleNo()
        {
            var entityList = await cmbl_SampleRepository.GetIQueryable()                
                 .Select(x => new SelectListItem()
                 {
                     Text = $"Sample-{x.SampleNo}({x.ApproxDeliveryDate.ToString("dd-MMM-yyyy")})",
                     Value = x.SampleNo.ToString()
                 }).OrderByDescending(x=>x.Value).ToListAsync();
            return entityList;
        }

        public async Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemList(long CompanyId, long RequisitionNo)
        {
            return await cmbl_SampleRepository.GetRequisitionWiseItemList(CompanyId, RequisitionNo);
        }

        public async Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemListForGateReceiving(long sampleNo)
        {
            return await cmbl_SampleRepository.GetRequisitionWiseItemListForGateReceiving(sampleNo);
        }

       
    }
}
