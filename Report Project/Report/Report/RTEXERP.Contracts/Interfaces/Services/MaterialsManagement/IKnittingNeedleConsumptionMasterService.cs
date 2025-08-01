using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
  public  interface IKnittingNeedleConsumptionMasterService
    {
        Task<RResult> SaveKnittingNeedleConsumptionData(KnittingNeedleConsumptionMasterViewModel model);
        Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsumptionList();
        Task<KnittingNeedleConsumptionMasterViewModel> GetKnittingNeedleConsumptionMasterData(int ID);
        Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsuptionByCompanyIDAndMachineNo(DateTime dateFrom, DateTime dateTo, int companyID = 0, int machineNo = 0);
    }
}
