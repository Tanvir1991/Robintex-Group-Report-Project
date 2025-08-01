using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class vw_OrderLotConfirmQuantityService : Ivw_OrderLotConfirmQuantityService
    {
        private readonly Ivw_OrderLotConfirmQuantityRepository _orderLotConfirmQuantityRepository;
        public vw_OrderLotConfirmQuantityService(Ivw_OrderLotConfirmQuantityRepository orderLotConfirmQuantityRepository)
        {
            _orderLotConfirmQuantityRepository = orderLotConfirmQuantityRepository;
        }
        public async  Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color)
        {
            return await _orderLotConfirmQuantityRepository.GetDDLOrderWiseLot(orderID, color);
        }
    }
}
