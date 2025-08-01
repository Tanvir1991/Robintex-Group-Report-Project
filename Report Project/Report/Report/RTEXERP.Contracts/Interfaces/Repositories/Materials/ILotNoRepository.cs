using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Materials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Materials
{
    public interface ILotNoRepository : IGenericRepository<YarnLotNo>
    {
        Task<List<SelectListItem>> DDLLotList(DateTime? DateTime,DateTime? DateTo);
    }
}
