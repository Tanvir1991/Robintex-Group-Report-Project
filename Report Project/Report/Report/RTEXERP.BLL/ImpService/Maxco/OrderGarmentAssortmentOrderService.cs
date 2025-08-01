using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class OrderGarmentAssortmentOrderService : IOrderGarmentAssortmentOrderService
    {
        private readonly IOrderGarmentAssortmentOrderRepository orderGarmentAssortmentOrderRepository;
        public OrderGarmentAssortmentOrderService(IOrderGarmentAssortmentOrderRepository _orderGarmentAssortmentOrderRepository)
        {
            orderGarmentAssortmentOrderRepository = _orderGarmentAssortmentOrderRepository;
        }
        public  async Task<List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>> Get_OrderGarmentAssortmentOrder_StyeAndSize(int StyleID)
        {
            return await orderGarmentAssortmentOrderRepository.Get_OrderGarmentAssortmentOrder_StyeAndSize(StyleID);
        }
    }
}
