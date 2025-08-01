using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.BLModels.EMS.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.EMS;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMS
{
  public  class EM_PIM_PACKINGINVOICE_MASTERService : IEM_PIM_PACKINGINVOICE_MASTERService
    {
        public readonly IEM_PIM_PACKINGINVOICE_MASTERRepository em_PIM_PACKINGINVOICE_MASTERRepository;
        public EM_PIM_PACKINGINVOICE_MASTERService(IEM_PIM_PACKINGINVOICE_MASTERRepository em_PIM_PACKINGINVOICE_MASTERRepository)
        {
            this.em_PIM_PACKINGINVOICE_MASTERRepository = em_PIM_PACKINGINVOICE_MASTERRepository;
        }

        public async Task<List<SelectListItem>> DDLExportInvoiceForExportVoucher(long CompanyID, DateTime InvoiceDate)
        {
            return await this.em_PIM_PACKINGINVOICE_MASTERRepository.DDLExportInvoiceForExportVoucher(CompanyID,InvoiceDate);
        }

        public async Task<List<SelectListItem>> DDLInvoiceNumber(long CompanyID)
        {
            return await em_PIM_PACKINGINVOICE_MASTERRepository.DDLInvoiceNumber(CompanyID);
        }

        public async Task<List<ExportInvoiceForExportVoucher>> ExportInvoiceForExportVoucher(long CompanyID,DateTime InvoiceDate)
        {
            return await em_PIM_PACKINGINVOICE_MASTERRepository.ExportInvoiceForExportVoucher(CompanyID,InvoiceDate);
        }

        public async Task<List<InvoiceOrderSPModel>> GetInvoiceOrder(int CompanyID,int InvoiceID)
        {
            return await em_PIM_PACKINGINVOICE_MASTERRepository.GetInvoiceOrder(CompanyID,InvoiceID);
        }
    }
}
