using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface ICMBL_SampleGateReceivingService
    {
        Task<RResult> SampleGateReceivingSave(CMBL_SampleGateReceivingViewModel model, int createdBy, bool saveChanges = true);
    }
}
