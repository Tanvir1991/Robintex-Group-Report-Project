using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface Ivw_OrderLotFinishQuantityRepository:IGenericRepository<vw_OrderLotFinishQuantity>
    {
        Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color);
        Task<vw_OrderLotFinishQuantity> GetOrderWiseLotFinishQuantity(int orderID,long lotID);
    }
}
