using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherModel;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
  public  interface IVoucherRepository :IGenericRepository<Voucher>
    {
        Task<List<Voucherdetail>> GetVoucherdetailAsync(Expression<Func<Voucherdetail, bool>> match);
        Task<GenerateVoucherNumber> GenerateVoucherNumber(int VoucherType,int CompanyId,int BusinessId,int Month,int Year);
        Task<GenerateVoucherNumber> GenerateVoucherNumber(string VoucherPrefix, int VoucherType, int CompanyId, int BusinessId, int Month, int Year);
        Task<GenerateVoucherNumber> AddStampVoucher(StampVoucherViewModel stampVoucherViewModel);
        Task<decimal> GetLedgerBalence(int AccountId, int VoucherType, DateTime FinDateFrom, DateTime FinDateTo);
        Task<RResult> SaveBankPaymentVoucher(Voucher masterVoucher, string locationInitial, bool? saveChange = true);
        Task<List<SelectListItem>> DDLVoucherNumberList(int VoucherType, int CompanyId, int Month, int Year);
    }
}
