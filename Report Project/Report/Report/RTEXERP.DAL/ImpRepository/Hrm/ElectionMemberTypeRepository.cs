using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Hrm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Hrm
{
   public class ElectionMemberTypeRepository :GenericRepository<ElectionMemberType>, IElectionMemberTypeRepository
    {
        private HRTESTContext dbCon;
        public ElectionMemberTypeRepository(HRTESTContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLElectionType()
        {

            var data =await dbCon.ElectionMemberType.Select(b => new SelectListItem
            {
                Text = b.TypeNameBN,
                Value = b.ID.ToString()
            }).ToListAsync();

            return data;
        }
    }
}
