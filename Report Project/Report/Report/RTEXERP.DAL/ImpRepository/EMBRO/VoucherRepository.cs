using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;
using System.Data;
using System.Data.Common;
using Snickler.EFCore;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherModel;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
  public  class VoucherRepository :GenericRepository<Voucher>, IVoucherRepository
    {
        private EmbroDBContext dbCon;

        public VoucherRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<Voucherdetail>> GetVoucherdetailAsync(Expression<Func<Voucherdetail, bool>> match)
        {
            var voucherDetail = await dbCon.Voucherdetail.Where(match).ToListAsync();
            return voucherDetail;
        }

        public async Task<GenerateVoucherNumber> AddStampVoucher(StampVoucherViewModel stampVoucherViewModel)
        {
            GenerateVoucherNumber generateVoucherNumber = new GenerateVoucherNumber();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                 new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted },
                                                 TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Voucher voucher = new Voucher();

                    VoucherGeneralInfo voucherGeneralInfo = new VoucherGeneralInfo();
                    var getVoucherNumber = await this.GenerateVoucherNumber(stampVoucherViewModel.VoucherNumber, stampVoucherViewModel.VoucherType.Value, stampVoucherViewModel.CompanyId, stampVoucherViewModel.BusinessId, stampVoucherViewModel.Vdate.Value.Month, stampVoucherViewModel.Vdate.Value.Year);
                    voucher.VoucherNumber = getVoucherNumber.VoucherNumber;
                    voucher.IndividualVoucherId = getVoucherNumber.SerialNumber;
                    voucher.VoucherType = stampVoucherViewModel.VoucherType;
                    voucher.Vdate = stampVoucherViewModel.Vdate;
                    voucher.CompanyId = stampVoucherViewModel.CompanyId;
                    voucher.BusinessId = stampVoucherViewModel.BusinessId;
                    voucher.PreparedBy = 33;
                    voucher.PrepareDate = DateTime.Now;
                    voucher.SystemVoucher = 0;
                    voucher.VoucherDescription = stampVoucherViewModel.VoucherDescription;

                    foreach (var vd in stampVoucherViewModel.voucherDetail)
                    {
                        Voucherdetail voucherdetail = new Voucherdetail();
                        voucherdetail.AccountId = vd.AccountId;
                        voucherdetail.Amount = (vd.Amount * stampVoucherViewModel.ExchangeRate);
                        voucherdetail.Status = "50";
                        voucherdetail.LocationId = vd.LocationId;
                        voucherdetail.Costcenter = vd.Costcenter;
                        voucherdetail.Activity = vd.Activity;
                        voucherdetail.Vindex = vd.Vindex;
                        voucherdetail.EntryType = vd.EntryType;
                        voucherdetail.AccountId = vd.AccountId;
                        voucher.Voucherdetail.Add(voucherdetail);
                    }
                    foreach (var vg in stampVoucherViewModel.VoucherGeneralInfo)
                    {
                        VoucherGeneralInfo voucherGeneral = new VoucherGeneralInfo();
                        voucherGeneral.AccountId = vg.AccountId;
                        voucherGeneral.Description = vg.Description;
                        voucherGeneral.Billno = vg.Billno;
                        voucherGeneral.Billdate = vg.Billdate;
                        voucherGeneral.RefNo = vg.RefNo;
                        voucherGeneral.Discount = vg.Discount;
                        voucherGeneral.Gross = (vg.Gross * stampVoucherViewModel.ExchangeRate);
                        voucherGeneral.Net = (vg.Net * stampVoucherViewModel.ExchangeRate);
                        voucherGeneral.Comments = vg.Comments;
                        voucherGeneral.InvoiceEffect = vg.InvoiceEffect == null ? 0 : vg.InvoiceEffect;
                        voucherGeneral.Vindex = vg.Vindex;
                        voucherGeneral.Currency = vg.Currency;
                        voucherGeneral.ConversionRate = stampVoucherViewModel.ExchangeRate;

                        voucher.VoucherGeneralInfo.Add(voucherGeneral);
                        voucher.JournalVoucherInfo.Add(new JournalVoucherInfo
                        {
                            ItemId = vg.AccountId,
                            Quantity = vg.Quantity,
                            Rate = vg.Rate,
                            Vindex = vg.Vindex
                        });

                    }

                    dbCon.Voucher.Add(voucher);
                    await dbCon.SaveChangesAsync();
                    generateVoucherNumber.VoucherNumber = voucher.VoucherNumber;
                    generateVoucherNumber.SerialNumber = (int)voucher.Id;

                  await  dbCon.Database.ExecuteSqlCommandAsync($"usp_APM_Invoice_Insert_AutoForSIV { (long)voucher.Id }");
                    scope.Complete();
                    return generateVoucherNumber;
                }
                catch (Exception e)
                {
                   scope.Dispose();
                    throw new Exception("Problem");
                }
            }
        }

        public async Task<GenerateVoucherNumber> GenerateVoucherNumber(int VoucherType, int CompanyId, int BusinessId, int Month, int Year)
        {
            GenerateVoucherNumber generateVoucherNumber = new GenerateVoucherNumber();

               var fsMonth =await dbCon.FiscalYearSetup.FirstAsync();
            if (Month < fsMonth.StartMonth)
            {
                Year -= 1;
            }

            var vinfo = from v in dbCon.Voucher
                        where v.VoucherType == VoucherType
                        && v.CompanyId == CompanyId
                        && v.BusinessId == BusinessId
                        && (v.Vdate.Value.Month < fsMonth.StartMonth == true ? v.Vdate.Value.Year - 1 : v.Vdate.Value.Year) == Year
                        //&& v.Vdate.Value.Year == Year
                        //orderby v.Id descending
                        select new GenerateVoucherNumber
                        {
   
                          SerialNumber= v.VoucherNumber!=null && v.VoucherNumber.Length == 12 ? Convert.ToInt32(v.VoucherNumber.Trim().Substring(v.VoucherNumber.Trim().Length - 5, 5)) :
                                   v.VoucherNumber != null && v.VoucherNumber.Length != 12 ? Convert.ToInt32(v.VoucherNumber.Trim().Substring(v.VoucherNumber.Trim().Length - 4, 4)) :
                                   0
                        };
            var VoucherNum = await vinfo.MaxAsync(b => b.SerialNumber)+1;
            var newVouchrNumber = VoucherNum.ToString("00000");
            generateVoucherNumber.SerialNumber = VoucherNum;
            generateVoucherNumber.VoucherNumber = newVouchrNumber;
            return generateVoucherNumber;

        }
        public async Task<GenerateVoucherNumber> GenerateVoucherNumber(string VoucherPrefix,int VoucherType, int CompanyId, int BusinessId, int Month, int Year)
        {
            try
            {
                GenerateVoucherNumber generateVoucherNumber = new GenerateVoucherNumber();
                var VoucherNum = 1;
               var fsMonth = await dbCon.FiscalYearSetup.FirstAsync();
               
                if (Month < fsMonth.StartMonth)
                {
                    Year -= 1;

                }


                var vinfo = from v in dbCon.Voucher
                            where v.VoucherType == VoucherType
                            && v.CompanyId == CompanyId
                            && v.BusinessId == BusinessId
                    /*dd*/  && (v.Vdate.Value.Month<fsMonth.StartMonth==true? v.Vdate.Value.Year-1:v.Vdate.Value.Year)  == Year
                            && v.VoucherNumber.StartsWith(VoucherPrefix)
                            select new  
                            {
                                SerialNumber = v.VoucherNumber != null && v.VoucherNumber.Length >= 12 ? Convert.ToInt32(v.VoucherNumber.Trim().Substring(v.VoucherNumber.Trim().Length - 5, 5)) :
                                               v.VoucherNumber != null && v.VoucherNumber.Length < 12 ? Convert.ToInt32(v.VoucherNumber.Trim().Substring(v.VoucherNumber.Trim().Length - 4, 4)) :
                                                  0,
                                   Vdate = v.Vdate
                            };
                //if (Month < fsMonth.StartMonth)
                //{
                //    vinfo = vinfo.Where(b => b.Vdate.Value.Year - 1 == Year);
                //}
                //else
                //{
                //    vinfo = vinfo.Where(b => b.Vdate.Value.Year == Year);
                //}
                var _vinfo = await vinfo.ToListAsync();

           if (_vinfo.Count > 0)
                {
                    VoucherNum = (_vinfo.Max(b => b.SerialNumber)) + 1;
                }
                var newVouchrNumber = VoucherNum.ToString("00000");
                generateVoucherNumber.SerialNumber = VoucherNum;
                generateVoucherNumber.VoucherNumber = $"{VoucherPrefix}{newVouchrNumber}";
                return generateVoucherNumber;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<decimal> GetLedgerBalence(int AccountId, int VoucherType, DateTime FinDateFrom, DateTime FinDateTo)
        {

            //decimal getlegerbalance = new decimal();
            decimal getlegerbalance = 0;
            DbParameter outputParam = null;
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_getLedgerBalance")
                .WithSqlParam("AccountId", AccountId)
                .WithSqlParam("VoucherType", VoucherType)
                .WithSqlParam("FinDateFrom", FinDateFrom)
                .WithSqlParam("FinDateTo", FinDateTo)
                .WithSqlParam("AccBalance", (dbParm) =>
                {
                    dbParm.Direction = System.Data.ParameterDirection.Output;
                    dbParm.DbType = System.Data.DbType.Decimal;
                    outputParam = dbParm;
                })
                .ExecuteStoredNonQueryAsync();

                getlegerbalance = (decimal)outputParam.Value;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return getlegerbalance;

        }

        public async Task<RResult> SaveBankPaymentVoucher(Voucher masterVoucher,string locationInitial, bool? saveChange = true)
        {
            var voucherPrefix = $"BPV\\{locationInitial}\\";
            RResult rResult = new RResult();
            try
            {var autoVoucherNumber= await this.GenerateVoucherNumber(voucherPrefix, masterVoucher.VoucherType.Value, masterVoucher.CompanyId, masterVoucher.BusinessId, masterVoucher.Vdate.Value.Month, masterVoucher.Vdate.Value.Year);
                masterVoucher.VoucherNumber = autoVoucherNumber.VoucherNumber;
                masterVoucher.IndividualVoucherId = autoVoucherNumber.SerialNumber; 
                dbCon.Voucher.Add(masterVoucher);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                rResult.longId = (long)masterVoucher.Id;
                rResult.statusMsg = autoVoucherNumber.VoucherNumber;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
            
        }

        public async Task<List<SelectListItem>> DDLVoucherNumberList(int VoucherType, int CompanyId, int Month, int Year)
        {
            var voucherList = await dbCon.Voucher
                .Where(v => v.VoucherType.Value == VoucherType
                            && v.CompanyId == CompanyId 
                            && v.Vdate.Value.Year == Year 
                            && v.Vdate.Value.Month == Month)
                .OrderBy(b=>b.SystemVoucher)
                .Select(x => new SelectListItem
                {
                    Text = x.VoucherNumber.Trim(),
                    Value = x.Id.ToString()
                }).ToListAsync();
            return voucherList;
        }
    }
}
