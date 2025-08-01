using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface ICMBL_SampleGateReceivingRepository:IGenericRepository<CMBL_SampleGateReceiving>
    {
        Task<RResult> SampleGateReceivingSave(CMBL_SampleGateReceivingViewModel model, int createdBy, bool saveChanges = true);
    }
}
