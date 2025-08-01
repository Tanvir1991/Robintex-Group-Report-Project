using AutoMapper;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class KnittingNeedleConsumptionMasterService : IKnittingNeedleConsumptionMasterService
    {
        private readonly IKnittingNeedleConsumptionMasterRepository knittingNeedleConsumptionMasterRepository;
        private readonly IMapper mapper;

        public KnittingNeedleConsumptionMasterService(IKnittingNeedleConsumptionMasterRepository _knittingNeedleConsumptionMasterRepository,
            IMapper _mapper)
        {
            knittingNeedleConsumptionMasterRepository = _knittingNeedleConsumptionMasterRepository;
            mapper = _mapper;
        }

        public async Task<KnittingNeedleConsumptionMasterViewModel> GetKnittingNeedleConsumptionMasterData(int ID)
        {
            return await knittingNeedleConsumptionMasterRepository.GetKnittingNeedleConsumptionMasterData(ID);
        }

        public async Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsumptionList()
        {
            return await knittingNeedleConsumptionMasterRepository.GetNittingNeedleConsumptionList();
        }

        public async Task<List<KnittingNeedleConsumptionViewModel>> GetNittingNeedleConsuptionByCompanyIDAndMachineNo(DateTime dateFrom, DateTime dateTo, int companyID = 0, int machineNo = 0)
        {
            return await knittingNeedleConsumptionMasterRepository.GetNittingNeedleConsuptionByCompanyIDAndMachineNo(dateFrom, dateTo, companyID, machineNo);
        }

        public async Task<RResult> SaveKnittingNeedleConsumptionData(KnittingNeedleConsumptionMasterViewModel model)
         {
            model.CreatedDate = DateTime.Now;


            model.KnittingNeedleConsumptionDetails.ForEach(b => { b.CreatedDate = DateTime.Now; b.CreatedBy = model.CreatedBy; });

            var mainObj = mapper.Map<KnittingNeedleConsumptionMasterViewModel, KnittingNeedleConsumptionMaster>(model);
            return await knittingNeedleConsumptionMasterRepository.SaveKnittingNeedleConsumptionData(mainObj);
        }
       
    }
}
