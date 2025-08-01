using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
  public interface IBuyer_SetupRepository
    {
        Task<List<SelectListItem>> DDLBuyer();
    }
}
