using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.CMS
{
    public interface IPro_MasterRepository :IGenericRepository<Pro_Master>
    {
        Task<List<SelectListItem>> DDLProductionOrder(DateTime ProductinDateFrom, DateTime ProductionDateTo, int BuyerID = 0);
    }
}
