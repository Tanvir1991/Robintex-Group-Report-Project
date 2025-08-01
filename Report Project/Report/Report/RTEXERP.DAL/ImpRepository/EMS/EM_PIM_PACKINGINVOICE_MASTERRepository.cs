using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.BLModels.EMS.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.EMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMS;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMS
{
    public class EM_PIM_PACKINGINVOICE_MASTERRepository : GenericRepository<EmPimPackinginvoiceMaster>, IEM_PIM_PACKINGINVOICE_MASTERRepository
    {
        private EMSDBContext dbCon;

        public EM_PIM_PACKINGINVOICE_MASTERRepository(EMSDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDLExportInvoiceForExportVoucher(long CompanyID,DateTime InvoiceDate)
        {
            var data = await this.ExportInvoiceForExportVoucher(CompanyID,InvoiceDate);
            return data.Select(s => new SelectListItem
            {
                Text = s.EPIM_INVOICENO,
                Value = s.EPIM_ID.ToString()
            }).ToList();
        }

        public async Task<List<SelectListItem>> DDLInvoiceNumber(long CompanyID)
        {
            DateTime fromDate = new DateTime(2018, 1, 1);
            var list = await dbCon.EmPimPackinginvoiceMaster.Where(x => x.EpimInvoicedate >= fromDate && x.EpimCompanyid==CompanyID)
                .Select(row => new SelectListItem
                {
                    Text = row.EpimInvoiceno,
                    Value = row.EpimId.ToString()
                }).ToListAsync();
            return list;
        }

        public async Task<List<ExportInvoiceForExportVoucher>> ExportInvoiceForExportVoucher(long CompanyID, DateTime InvoiceDate)
        {
            List<ExportInvoiceForExportVoucher> returnStr = new List<ExportInvoiceForExportVoucher>();
            try
            {
                await dbCon.LoadStoredProc("rpt.Get_ExportInvoiceForStamp")
                      .WithSqlParam("CompanyID", CompanyID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnStr = handler.ReadToList<ExportInvoiceForExportVoucher>() as List<ExportInvoiceForExportVoucher>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnStr;
        }

       

        public async Task<List<EmPimPackinginvoiceMaster>> GetInvoiceMasterByInvoiceNoList(List<string> InvoiceNoList, int CompanyID)
        {
            var list = await dbCon.EmPimPackinginvoiceMaster.Where(x => InvoiceNoList.Contains(x.EpimInvoiceno.Trim()) && x.EpimCompanyid==CompanyID).ToListAsync();
            return list;
        }

        public async Task<List<InvoiceOrderSPModel>> GetInvoiceOrder(int CompanyID,int InvoiceID)
        {
            List<InvoiceOrderSPModel> returnStr = new List<InvoiceOrderSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetInvoiceOrder")
                      .WithSqlParam("CompanyID", CompanyID)
                      .WithSqlParam("InvoiceID", InvoiceID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnStr = handler.ReadToList<InvoiceOrderSPModel>() as List<InvoiceOrderSPModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnStr;
        }
    }
}
