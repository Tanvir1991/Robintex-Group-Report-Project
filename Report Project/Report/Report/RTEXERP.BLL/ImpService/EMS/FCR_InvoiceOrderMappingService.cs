using Microsoft.EntityFrameworkCore.Internal;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMS;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using RTEXERP.DBEntities.EMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMS
{
    public class FCR_InvoiceOrderMappingService : IFCR_InvoiceOrderMappingService
    {
        private readonly IFCR_InvoiceOrderMappingRepository fcr_InvoiceOrderMappingRepository;
        private readonly IEM_PIM_PACKINGINVOICE_MASTERRepository eM_PIM_PACKINGINVOICE_MASTERRepository;
        private readonly IStyleRepository styleRepository;
        public FCR_InvoiceOrderMappingService(IFCR_InvoiceOrderMappingRepository fcr_InvoiceOrderMappingRepository
            , IEM_PIM_PACKINGINVOICE_MASTERRepository eM_PIM_PACKINGINVOICE_MASTERRepository
            , IStyleRepository styleRepository)
        {
            this.fcr_InvoiceOrderMappingRepository = fcr_InvoiceOrderMappingRepository;
            this.eM_PIM_PACKINGINVOICE_MASTERRepository = eM_PIM_PACKINGINVOICE_MASTERRepository;
            this.styleRepository = styleRepository;
        }

        public async Task<List<FCR_InvoiceOrderMappingViewModel>> FCR_InvoiceOrderMappingDetail(int InvoiceID)
        {
            return await fcr_InvoiceOrderMappingRepository.FCR_InvoiceOrderMappingDetail(InvoiceID);
        }

        public async Task<RResult> FCR_InvoiceOrderMappingSave(FCR_InvoiceOrderMapping entity, bool? saveChange = true)
        {
            return await fcr_InvoiceOrderMappingRepository.FCR_InvoiceOrderMappingSave(entity, saveChange);
        }

        public async Task<RResult> FCR_InvoiceOrderMappingSave(List<FCR_InvoiceOrderMapping> entity, bool? saveChange = true)
        {
            return await fcr_InvoiceOrderMappingRepository.FCR_InvoiceOrderMappingSave(entity, saveChange);
        }

        public async Task<List<GSPInvoiceDataModel>> InvoiceOrderMappingValidation(string OrderNoXML, int CompanyID,int ExportServiceTypeID)
        {
            return await fcr_InvoiceOrderMappingRepository.InvoiceOrderMappingValidation(OrderNoXML, CompanyID,ExportServiceTypeID);
        }

        public async Task<List<FCR_InvoiceOrderMappingViewModel>> InvoiceOrderFCRDataValidation(List<FCR_InvoiceOrderMappingViewModel> dataList, string OrderNoXML, int CompanyID)
        {
            //List<FCR_InvoiceOrderMappingViewModel> rList = new List<FCR_InvoiceOrderMappingViewModel>();
            //try
            //{                
            //    var invoiceList = await eM_PIM_PACKINGINVOICE_MASTERRepository.GetInvoiceMasterByInvoiceNoList(dataList.Select(x => x.InvoiceNo.Trim()).Distinct().ToList(), CompanyID);
            //    var orderList = await styleRepository.GetOrderByOrderNoList(OrderNoXML);
            //    rList = (from data in dataList
            //             join invoice in invoiceList on data.InvoiceNo equals invoice.EpimInvoiceno into inv
            //             from invoice in inv.DefaultIfEmpty()
            //             join order in orderList on data.OrderNo equals order.OrderNo into ord
            //             from order in ord.DefaultIfEmpty()
            //             select new FCR_InvoiceOrderMappingViewModel
            //             {
            //                 Sl=data.Sl,
            //                 InvoiceID = invoice == null ? 0: invoice.EpimId,
            //                 InvoiceNo = data.InvoiceNo,
            //                 OrderID = order==null? 0:order.ID,
            //                 OrderNo = data.OrderNo,
            //                 FCRNo = data.FCRNo,
            //                 FCRDateMSG = data.FCRDateMSG
            //             }).ToList();
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            return await fcr_InvoiceOrderMappingRepository.ValidateFCR_InvoiceOrderMapping(OrderNoXML);
        }
    }
}
