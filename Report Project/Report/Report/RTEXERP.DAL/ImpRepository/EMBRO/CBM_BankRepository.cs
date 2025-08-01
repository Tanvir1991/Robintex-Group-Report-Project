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
    public class CBM_BankRepository : GenericRepository<CbmBank>, ICBM_BankRepository
    {

        private EmbroDBContext dbCon;

        public CBM_BankRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDL_CBM_Bank(decimal CompanyID)
        {
            var bank = dbCon.CbmBank
                       .Where(b => b.CompanyId == CompanyID)
                       .Select(b => new SelectListItem
                       {
                           Text = b.BankName,
                           Value = b.BankId.ToString()
                       });

            return await bank.ToListAsync();
        }
    }
}
