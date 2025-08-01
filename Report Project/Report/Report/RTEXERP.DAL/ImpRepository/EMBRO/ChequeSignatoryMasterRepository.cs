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
    public class ChequeSignatoryMasterRepository:GenericRepository<ChequeSignatoryMaster>, IChequeSignatoryMasterRepository
    {
        private EmbroDBContext dbCon;

        public ChequeSignatoryMasterRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyId)
        {
            var list = await dbCon.ChequeSignatoryMaster
                .Where(x=>x.CompanyId==companyId)
                .Select(x => new SelectListItem
                {
                    Text = x.Description,
                    Value = x.Id.ToString()
                }).ToListAsync();
            return list;
        }
    }
}
