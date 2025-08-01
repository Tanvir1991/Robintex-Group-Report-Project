using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Materials
{
    public interface ILotNoService
    {
        Task<List<SelectListItem>> DDLLotList(DateTime? DateFrom,DateTime? DateTo);

    }
}
