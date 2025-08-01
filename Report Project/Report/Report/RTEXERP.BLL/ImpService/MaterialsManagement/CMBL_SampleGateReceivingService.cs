using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class CMBL_SampleGateReceivingService : ICMBL_SampleGateReceivingService
    {
        private readonly ICMBL_SampleGateReceivingRepository cmbl_SampleGateReceivingRepository;
        public CMBL_SampleGateReceivingService(ICMBL_SampleGateReceivingRepository cmbl_SampleGateReceivingRepository)
        {
            this.cmbl_SampleGateReceivingRepository = cmbl_SampleGateReceivingRepository;
        }
        public async Task<RResult> SampleGateReceivingSave(CMBL_SampleGateReceivingViewModel model, int createdBy, bool saveChanges = true)
        {
            return await cmbl_SampleGateReceivingRepository.SampleGateReceivingSave(model, createdBy, saveChanges);
        }
    }
}
