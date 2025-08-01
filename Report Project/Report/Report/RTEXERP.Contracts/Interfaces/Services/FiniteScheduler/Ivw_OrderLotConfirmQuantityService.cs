using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
  public  interface Ivw_OrderLotConfirmQuantityService
    {
        Task<List<SelectListItem>> GetDDLOrderWiseLot(int orderID, string color);
    }
}
