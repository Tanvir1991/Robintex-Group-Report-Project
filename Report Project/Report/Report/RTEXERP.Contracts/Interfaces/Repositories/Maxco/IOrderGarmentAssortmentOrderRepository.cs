using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IOrderGarmentAssortmentOrderRepository :IGenericRepository<Style>
    {
        Task<List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>> Get_OrderGarmentAssortmentOrder_StyeAndSize(int StyleID);
    }
}
