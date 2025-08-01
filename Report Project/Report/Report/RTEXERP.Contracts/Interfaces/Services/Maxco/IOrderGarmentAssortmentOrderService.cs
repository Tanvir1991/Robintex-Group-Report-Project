using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
  public  interface IOrderGarmentAssortmentOrderService
    {
        Task<List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>> Get_OrderGarmentAssortmentOrder_StyeAndSize(int StyleID);
    }
}
