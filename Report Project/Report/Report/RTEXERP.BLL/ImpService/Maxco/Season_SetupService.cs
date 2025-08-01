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
    public class Season_SetupService : ISeason_SetupService
    {
        private readonly ISeason_SetupRepository _Season_SetupRepository;
        public Season_SetupService(ISeason_SetupRepository Season_SetupRepository)
        {
            _Season_SetupRepository = Season_SetupRepository;
        }

        public async Task<List<DropDownItem>> DDLSeason()
        {
            var list = await _Season_SetupRepository.GetAllAsync();
            var rList = list.Select(b => new DropDownItem { Text = b.Description.Trim(),Value =b.ID.ToString(),Custome1 = b.SeasonCode.Trim()  });
            return rList.ToList();
        }
    }
}
