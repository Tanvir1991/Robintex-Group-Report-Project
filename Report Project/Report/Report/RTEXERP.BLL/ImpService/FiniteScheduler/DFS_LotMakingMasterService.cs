using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
   public class DFS_LotMakingMasterService : IDFS_LotMakingMasterService
    {
        private readonly IDFS_LotMakingMasterRepository _dfs_LotMakingMasterRepository;

        public DFS_LotMakingMasterService(IDFS_LotMakingMasterRepository dfs_LotMakingMasterRepository)
        {
            _dfs_LotMakingMasterRepository = dfs_LotMakingMasterRepository;
        }

        public async Task<List<SelectListItem>> DDLLot(DateTime CreationDateFrom, DateTime CreationDateTo, string Predict = null)
        {
            return await _dfs_LotMakingMasterRepository.DDLLot(CreationDateFrom,CreationDateTo,Predict);
        }

        public async Task<List<SelectListItem>> DDLLotRequisition(DateTime LotDateFrom, DateTime LotDateTo, string Predict = null, long OrderID = 0)
        {
            return await _dfs_LotMakingMasterRepository.DDLLotRequisition(LotDateFrom, LotDateTo, Predict,OrderID);
        }

        public async  Task<List<OrderWiseLotRequisitionVM>> GetOrderWiseLotRequisitionList(int OrderID)
        {
            return await _dfs_LotMakingMasterRepository.GetOrderWiseLotRequisitionList(OrderID);
        }
    }
}
