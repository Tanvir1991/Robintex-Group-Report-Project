using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.CMS
{
    public interface IPro_MasterService
    {
        Task<List<SelectListItem>> DDLProductionOrder(DateTime? ProductinDateFrom=null, DateTime? ProductionDateTo=null, int? BuyerID = 0);
    }
}
