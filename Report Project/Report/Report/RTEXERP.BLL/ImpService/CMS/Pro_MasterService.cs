using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.CMS
{
   public class Pro_MasterService : IPro_MasterService
    {
        private readonly IPro_MasterRepository _pro_MasterRepository;
        public Pro_MasterService(IPro_MasterRepository pro_MasterRepository)
        {
            _pro_MasterRepository = pro_MasterRepository;
        }

        public async Task<List<SelectListItem>> DDLProductionOrder(DateTime? ProductinDateFrom, DateTime? ProductionDateTo, int? BuyerID = 0)
        {
            DateTime _ProductinDateFrom =  DateTime.Now.AddYears(-1);
            DateTime _ProductionDateTo = DateTime.Now;
            int buyerID = 0;
            if (ProductinDateFrom.HasValue == true)
            {
                _ProductinDateFrom = ProductinDateFrom.Value;
            }
            if (ProductionDateTo.HasValue == true)
            {
                _ProductionDateTo = ProductionDateTo.Value;
            }
            if (BuyerID.HasValue == true)
            {
                buyerID = BuyerID.Value;
            }
            var OrderList = await _pro_MasterRepository.DDLProductionOrder(_ProductinDateFrom, _ProductionDateTo, buyerID);
            return OrderList;
        }
    }
}
