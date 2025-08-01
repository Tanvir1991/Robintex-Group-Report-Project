using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{

    public class CBM_BranchRepository : GenericRepository<CbmBranch>, ICBM_BranchRepository
    {

        private EmbroDBContext dbCon;

        public CBM_BranchRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDL_CBMBankBranch(decimal CompanyID, int BankID)
        {
            var list = from b in dbCon.CbmBank
                       join bb in dbCon.CbmBranch on b.BankId equals bb.BankId
                       where b.CompanyId == CompanyID
                       select new { b,bb};
            if (BankID > 0)
            {
                list = list.Where(b => b.bb.BankId == BankID);
            }

            var returnList = list.Select(b =>
            new SelectListItem
            {
                Text = b.bb.BranchName,
                Value = b.bb.BranchId.ToString()
            });
            return await returnList.ToListAsync();
        }
    }
}
