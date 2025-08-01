using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface Ivw_OrderLotConfirmQuantityRepository:IGenericRepository<vw_OrderLotConfirmQuantity>
    {
        Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color);
    }
}
