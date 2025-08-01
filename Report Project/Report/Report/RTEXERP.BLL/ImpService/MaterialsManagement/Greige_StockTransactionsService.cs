using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class Greige_StockTransactionsService : IGreige_StockTransactionsService
    {
        private readonly IGreige_StockTransactionsRepository _greige_StockTransactionsRepository;

        public Greige_StockTransactionsService(IGreige_StockTransactionsRepository greige_StockTransactionsRepository)
        {
            _greige_StockTransactionsRepository = greige_StockTransactionsRepository;
        }
        public async Task<List<GetKnittingProductionSPModel>> GetKnittingProduction(DateTime DateFrom, DateTime DateTo, int CompanyID = 0, int MachineID = -1)
        {
            return await _greige_StockTransactionsRepository.GetKnittingProduction(DateFrom, DateTo, CompanyID, MachineID);
        }

        public async Task<List<MachineProductionRollSPModel>> GetMachineProductionRollDetails(DateTime DateFrom, DateTime DateTo, int MachineID = 0)
        {
            return await _greige_StockTransactionsRepository.GetMachineProductionRollDetails(DateFrom, DateTo, MachineID);
        }

        public async Task<List<OrderKnittingProductionSPModel>> GetOrderKnittingProduction(long OrderID)
        {
            return await _greige_StockTransactionsRepository.GetOrderKnittingProduction(OrderID);
        }
    }
}
