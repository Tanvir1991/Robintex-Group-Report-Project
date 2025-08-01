using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class CBM_Instrument_TypeRepository : GenericRepository<CBM_Instrument_Type>, ICBM_Instrument_TypeRepository
    {
        private EmbroDBContext dbCon;
        public CBM_Instrument_TypeRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> DDLCBM_Instrument_TypeList()
        {
            var list = await dbCon.CBM_Instrument_Type.Where(b=>b.TypeId>0)
                .Select(x => new SelectListItem
                {
                    Text = x.TypeName,
                    Value = x.TypeId.ToString()
                }).ToListAsync();
            return list;
        }
    }
}
