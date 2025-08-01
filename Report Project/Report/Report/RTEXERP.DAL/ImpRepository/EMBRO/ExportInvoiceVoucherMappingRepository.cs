using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class ExportInvoiceVoucherMappingRepository : GenericRepository<ExportInvoiceVoucherMapping>, IExportInvoiceVoucherMappingRepository
    {
        private EmbroDBContext dbCon;
        public ExportInvoiceVoucherMappingRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<string> AutoExportInvoiceVoucherMappingNo(int ExportInvoiceTypeID, DateTime voucherDate)
        {


            var MappingNoList = await (from m in dbCon.ExportInvoiceVoucherMapping
                                       where m.ExportInvoiceTypeID == ExportInvoiceTypeID
                                       && m.VoucherDate.Year == voucherDate.Year
                                       select new {
                                            MappingNo = Convert.ToInt32(m.MappingNo.Substring(m.MappingNo.Length - 5, 5)) 
                                       })
                                       .ToListAsync();
            if (MappingNoList.Count > 0)
            {
                var mNo = MappingNoList.Max(x => x.MappingNo);
                mNo++;
                return mNo.ToString("00000");
            }
            else
            {
                return "00001";
            }
        }

        public async Task<List<SelectListItem>> DDLExportVoucher(long CompanyID,int ExportTypeID)
        {
            List <SelectListItem > rVoucher = new List<SelectListItem>();
            /*
            var _previousList = from pav in dbCon.AdvancePayment
                                join pv in dbCon.Voucher on pav.Voucherid.Value equals (long)pv.Id
                                join EADM in dbCon.ExportInvoiceAdjustMaster on pv.Id equals EADM.VoucherID into EVoucher
                                from EADM in EVoucher.DefaultIfEmpty()
                                where EADM == null && pv.Vdate.Value >= DateTime.Now.AddMonths(-4)
                                && pv.CompanyId==(int)CompanyID
                                select new SelectListItem
                                {
                                    Value = pv.Id.ToString(),
                                    Text = pv.VoucherNumber
                                };
            List<SelectListItem> previousVoucherList = await _previousList.ToListAsync();
            rVoucher.AddRange(previousVoucherList);
            */
           var _Data = from EIVM in dbCon.ExportInvoiceVoucherMapping
                        join V in dbCon.Voucher on EIVM.VoucherID equals (long)V.Id
                        join EADM in dbCon.ExportInvoiceAdjustMaster on EIVM.VoucherID equals EADM.VoucherID into EVoucher
                        from EADM in EVoucher.DefaultIfEmpty()
                        where EADM == null && V.CompanyId== (int)CompanyID
                        && EIVM.ExportInvoiceTypeID == ExportTypeID
                        select new SelectListItem
                        {
                            Value = EIVM.VoucherID.ToString(),
                            Text = V.VoucherNumber
                        };
            var newData = await _Data.ToListAsync();
            rVoucher.AddRange(newData);
           return rVoucher;
       
        }

        public async Task<RResult> SaveExportInvoiceVoucherMapping(ExportInvoiceVoucherMapping model, bool? saveChange = true)
        {
            RResult rResult = new RResult();
            try
            {
                var autoMappingId = await this.AutoExportInvoiceVoucherMappingNo(model.ExportInvoiceTypeID, model.VoucherDate);
                model.MappingNo = model.MappingNo + "-" + autoMappingId;

                dbCon.ExportInvoiceVoucherMapping.Add(model);
                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
