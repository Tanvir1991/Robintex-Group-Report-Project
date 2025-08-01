using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class MER_ZoneService : IMER_ZoneService
    {
        private readonly IMER_ZoneRepository _mer_ZoneRepository;
        public MER_ZoneService(IMER_ZoneRepository mer_ZoneRepository)
        {
            _mer_ZoneRepository = mer_ZoneRepository;
        }

        public async Task<List<DropDownItem>> DDLZone()
        {
            var list = await _mer_ZoneRepository.FindAllAsync(b => b.IsRemoved == false && b.IsActive == true);
            var rList = list.Select(b => new DropDownItem { Text = b.ZoneName,Value =b.ZoneID.ToString() ,Custome1 = b.ZoneCode });
            return rList.ToList();
                       
        }
    }
}
