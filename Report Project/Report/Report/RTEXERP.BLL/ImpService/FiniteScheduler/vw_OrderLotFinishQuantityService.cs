using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class vw_OrderLotFinishQuantityService : Ivw_OrderLotFinishQuantityService
    {
        private readonly Ivw_OrderLotFinishQuantityRepository vw_OrderLotFinishQuantityRepository;
        public vw_OrderLotFinishQuantityService(Ivw_OrderLotFinishQuantityRepository vw_OrderLotFinishQuantityRepository)
        {
            this.vw_OrderLotFinishQuantityRepository = vw_OrderLotFinishQuantityRepository;
        }
        public async Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color)
        {
            return await vw_OrderLotFinishQuantityRepository.GetDDLOrderWiseLot(orderID,color);
        }

        public async Task<vw_OrderLotFinishQuantity> GetOrderWiseLotFinishQuantity(int orderID, long lotID)
        {
            return await vw_OrderLotFinishQuantityRepository.GetOrderWiseLotFinishQuantity(orderID, lotID);
        }
    }
}
