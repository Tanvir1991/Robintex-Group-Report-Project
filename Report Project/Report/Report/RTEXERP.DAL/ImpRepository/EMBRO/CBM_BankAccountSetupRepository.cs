using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using RTEXERP.DAL.Extension;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class CBM_BankAccountSetupRepository : GenericRepository<CbmBankAccountSetup>, ICBM_BankAccountSetupRepository
    {

        private EmbroDBContext dbCon;

        public CBM_BankAccountSetupRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDLBankAccount(int BranchID)
        {
            /*
            var _fiscalYear = @"SELECT   ltrim(cast((select startmonth FROM FiscalYearSetup)AS VARCHAR(2))) + '/1/' + ltrim(str(MAX(ob.FiscalYear)-1)) as FiscaleDate
                                             FROM OpeningBalances AS ob";
            var fiscaleDT = dbCon.DataTableSqlQuery(_fiscalYear,  new DbParameter[0]);
            var FiscaleDate = Convert.ToDateTime(fiscaleDT.Rows[0]["FiscaleDate"].ToString());
            */
            var list = from bb in dbCon.CbmBranch
                       join bac in dbCon.CbmBankAccountSetup on bb.BranchId equals bac.BranchId
                       //join cqBook in dbCon.CbmChequeBook on bac.BaccountId equals cqBook.AccountId
                       //join cq in dbCon.CbmCheque on cqBook.Id equals cq.ChqBkId
                       where bb.BranchId == BranchID //&& cq.ChqDate>= FiscaleDate
                       select new SelectListItem
                       {
                           Text = bac.BaccountName,
                           Value = bac.BaccountId.ToString()
                       };
            return await list.ToListAsync();
                 
        }
    }
}
