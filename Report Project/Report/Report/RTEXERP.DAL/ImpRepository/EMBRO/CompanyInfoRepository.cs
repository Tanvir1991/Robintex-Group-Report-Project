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
    public class CompanyInfoRepository : GenericRepository<CompanyInfo>, ICompanyInfoRepository
    {
        private EmbroDBContext dbCon;

        public CompanyInfoRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> GetDDLCompanyInfo()
        {
            var rtnList = await dbCon.CompanyInfo.Select(b => new SelectListItem()
            {
                Text=b.Companyname,
                Value=b.CompanyId.ToString()
            }).ToListAsync();
            return rtnList;
        }
    }
}
