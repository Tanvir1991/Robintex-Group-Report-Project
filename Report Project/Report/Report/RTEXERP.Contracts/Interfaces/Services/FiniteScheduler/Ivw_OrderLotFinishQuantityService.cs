using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface Ivw_OrderLotFinishQuantityService
    {
        Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color);
        Task<vw_OrderLotFinishQuantity> GetOrderWiseLotFinishQuantity(int orderID, long lotID);
    }
}
