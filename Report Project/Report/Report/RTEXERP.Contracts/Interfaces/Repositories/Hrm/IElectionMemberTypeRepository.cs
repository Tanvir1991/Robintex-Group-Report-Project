using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Hrm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Hrm
{
   public interface IElectionMemberTypeRepository :IGenericRepository<ElectionMemberType>
    {
        Task<List<SelectListItem>> DDLElectionType();
    }
}
