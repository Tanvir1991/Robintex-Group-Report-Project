using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface ISeason_SetupService
    {
        Task<List<DropDownItem>> DDLSeason();
    }
}
