using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMBRO.VoucherModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.Embro;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository voucherRepository;
        private readonly IVoucherTypeRepository voucherTypeRepository;
        private readonly ILocationRepository locationRepository;
        private readonly Itbl_Currency_DetailRepository itbl_Currency_DetailRepository;
        private readonly IMapper mapper;
        private readonly ITblCbmAdvancePaymentRepository tblCbmAdvancePaymentRepository;
        private readonly ICBM_ChequeRepository cbm_ChequeRepository;
        private readonly ICbmChequeBookRepository cbmChequeBookRepository;
        private readonly IExportInvoiceVoucherMappingRepository exportInvoiceVoucherMappingRepository;
        public VoucherService(IVoucherRepository voucherRepository, IVoucherTypeRepository voucherTypeRepository, ILocationRepository locationRepository
            , Itbl_Currency_DetailRepository itbl_Currency_DetailRepository, IMapper mapper, ITblCbmAdvancePaymentRepository tblCbmAdvancePaymentRepository
            , ICBM_ChequeRepository cbm_ChequeRepository, ICbmChequeBookRepository cbmChequeBookRepository
            , IExportInvoiceVoucherMappingRepository exportInvoiceVoucherMappingRepository)
        {
            this.voucherRepository = voucherRepository;
            this.voucherTypeRepository = voucherTypeRepository;
            this.locationRepository = locationRepository;
            this.itbl_Currency_DetailRepository = itbl_Currency_DetailRepository;
            this.mapper = mapper;
            this.tblCbmAdvancePaymentRepository = tblCbmAdvancePaymentRepository;
            this.cbm_ChequeRepository = cbm_ChequeRepository;
            this.cbmChequeBookRepository = cbmChequeBookRepository;
            this.exportInvoiceVoucherMappingRepository = exportInvoiceVoucherMappingRepository;
        }

        public async Task<GenerateVoucherNumber> AddStampVoucher(StampVoucherViewModel stampVoucherViewModel)
        {
            var voucherType = await this.voucherTypeRepository.GetVoucherType(stampVoucherViewModel.VoucherType.Value);
            var location = await this.locationRepository.GetLocation(stampVoucherViewModel.LocationId);
            var voucherNumber = $"{voucherType.Initials}\\{location.LocationInitials}\\";
            stampVoucherViewModel.VoucherNumber = voucherNumber;
            var currencyRate = await itbl_Currency_DetailRepository.GetDateCurrencyRate(stampVoucherViewModel.Vdate.Value, stampVoucherViewModel.CurrencyId);
            stampVoucherViewModel.ExchangeRate = currencyRate.RateInPakRs.Value;

            return await this.voucherRepository.AddStampVoucher(stampVoucherViewModel);
        }

        public async Task<List<SelectListItem>> DDLVoucherNumberList(int VoucherType, int CompanyId, int Month, int Year)
        {
            return await voucherRepository.DDLVoucherNumberList(VoucherType, CompanyId, Month, Year);
        }

        public async Task<List<SelectListItem>> DDLVoucherTypeList(List<int> Ids)
        {
            return await voucherTypeRepository.DDLVoucherTypeList(Ids);
        }

        public async Task<GenerateVoucherNumber> GenerateVoucherNumber(int VoucherType, int CompanyId, int BusinessId, int Month, int Year)
        {
            return await this.voucherRepository.GenerateVoucherNumber(VoucherType, CompanyId, BusinessId, Month, Year);
        }

        public async Task<GenerateVoucherNumber> GenerateVoucherNumber(string VoucherPrefix, int VoucherType, int CompanyId, int BusinessId, int Month, int Year)
        {
            return await this.voucherRepository.GenerateVoucherNumber(VoucherPrefix, VoucherType, CompanyId, BusinessId, Month, Year);
        }

        public async Task<decimal> GetLedgerBalence(int AccountId, int VoucherType, DateTime FinDateFrom, DateTime FinDateTo)
        {
            return await voucherRepository.GetLedgerBalence(AccountId, VoucherType, FinDateFrom, FinDateTo);
        }

        public async Task<List<Voucherdetail>> GetVoucherdetailAsync(Expression<Func<Voucherdetail, bool>> match)
        {
            return await voucherRepository.GetVoucherdetailAsync(match);
        }

        public async Task<RResult> SaveBankPaymentVoucher(VoucherViewModel masterVoucher, InstrumentViewModel InstrumentObj, bool? saveChange = true)
        {
            RResult rResult = new RResult();
            string VoucherNumber = "";

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                 new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted },
                                                 TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var _BankVoucherInfo = masterVoucher.BankVoucherInfo.FirstOrDefault();
                    var locationInitial = (await locationRepository.GetLocation(masterVoucher.Voucherdetail.First().LocationId.Value)).LocationInitials;
                    var bankAccId = _BankVoucherInfo.AccountId;
                    decimal InstrumentTypeId = _BankVoucherInfo.InstrumentTypeId.Value;

                    if (bankAccId > 0 && (InstrumentTypeId == 1 || InstrumentTypeId == 2))
                    {
                        var instrumentInfo = new InstrumentViewModel();
                        instrumentInfo = await cbm_ChequeRepository.GetInstrumentNo((int)bankAccId);
                        InstrumentObj.InstrumentId = instrumentInfo.InstrumentId;
                        InstrumentObj.InstrumentNo = instrumentInfo.InstrumentNo;

                        masterVoucher.BankVoucherInfo.ToList().ForEach(x => { x.InstrumentId = instrumentInfo.InstrumentId.ToString(); x.InstrumentNo = instrumentInfo.InstrumentNo; });
                    }

                    var voucher = mapper.Map<VoucherViewModel, Voucher>(masterVoucher);
                    if ((InstrumentTypeId == 1 || InstrumentTypeId == 2) && InstrumentObj.InstrumentId > 0)
                    {
                        rResult = await voucherRepository.SaveBankPaymentVoucher(voucher, locationInitial, true);
                        VoucherNumber = rResult.statusMsg;
                    }
                    else if (InstrumentTypeId != 1 || InstrumentTypeId != 2)
                    {
                        rResult = await voucherRepository.SaveBankPaymentVoucher(voucher, locationInitial, true);
                        VoucherNumber = rResult.statusMsg;
                    }
                    else
                    {
                        rResult.result = 0;
                        rResult.message = "No Cheque Found for this Bank.";
                        scope.Dispose();
                        return rResult;
                    }


                    if (rResult.longId > 0 && bankAccId > 0 && (InstrumentTypeId == 1 || InstrumentTypeId == 2))
                    {
                        var cbmCheque = new CbmCheque()
                        {
                            Status = 6,
                            ChqAmount = InstrumentObj.ChqAmount,
                            ChqDate = InstrumentObj.ChqDate,
                            ChqDescription = InstrumentObj.ChequeNarration,
                            VoucherId = rResult.longId,
                            ChequeSignatoryId = InstrumentObj.ChequeSignatoryId,
                            ChqId = InstrumentObj.InstrumentId
                        };
                        var res = await cbm_ChequeRepository.UpdateCbmCheque(cbmCheque, true);
                        var chkBkRes = await cbmChequeBookRepository.UpdateCbmChequeBookStatus("Unused", res.longId);
                    }
                    if (rResult.longId > 0)
                    {
                        if (masterVoucher.PaymentTypeId == 1)
                        {

                        }
                        else if (masterVoucher.PaymentTypeId == 2)
                        {

                        }
                        else if (masterVoucher.PaymentTypeId == 3)
                        {
                            var _advPaymentList = await voucherRepository.GetVoucherdetailAsync(b => b.VoucherId == rResult.longId && b.EntryType == 1);

                            var advPaymentList = _advPaymentList
                              .Select(s => new TblCbmAdvancePayment
                              {
                                  VoucherId = s.VoucherId,
                                  AccountId = s.AccountId,
                                  Vid = s.Vid,
                                  Vindex = s.Vindex
                              }).ToList();

                            //    var advPaymentObjList = mapper.Map<List<Voucherdetail>, List<TblCbmAdvancePayment>>(advPaymentList);
                            //   advPaymentObjList.ForEach(x => { x.VoucherId = rResult.longId; });
                            var advPaymentResult = await tblCbmAdvancePaymentRepository.SaveTblCbmAdvancePayment(advPaymentList, true);
                        }
                    }

                    var exModel = new ExportInvoiceVoucherMapping()
                    {
                        VoucherID = rResult.longId,
                        VoucherDate = masterVoucher.Vdate.Value,
                        ExportInvoiceTypeID = InstrumentObj.ExportInvoiceTypeID,
                        MappingNo = InstrumentObj.ExportInvoiceType + "-" + masterVoucher.Vdate.Value.Year.ToString(),
                        CreateDate = DateTime.Now
                    };
                    var exInvRes = await exportInvoiceVoucherMappingRepository.SaveExportInvoiceVoucherMapping(exModel, true);
                    scope.Complete();
                    rResult.result = 1;
                    
                    string returnMessage = $"Voucher Create Successfully.<br/>Voucher Number : <b>{VoucherNumber}</b>";
                    rResult.message = returnMessage;
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    throw new Exception(e.Message);
                }
            }
            
            return rResult;
        }
    }
}
