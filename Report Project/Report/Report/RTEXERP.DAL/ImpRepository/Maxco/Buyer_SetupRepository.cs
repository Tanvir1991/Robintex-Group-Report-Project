using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
  public  class Buyer_SetupRepository :GenericRepository<Buyer_Setup>,IBuyer_SetupRepository
    {
        private MaxcoDBContext dbCon;

        public Buyer_SetupRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> DDLBuyer()
        {
            var buyerList =await dbCon.Buyer_Setup.Select(b => new SelectListItem
            {
                Text = b.Description.Trim(),
                Value = b.ID.ToString()
            }).ToListAsync();
            return buyerList;
        }
    }
}
