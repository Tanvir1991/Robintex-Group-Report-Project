using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMS;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class ExportInvoiceAdjustMasterService : IExportInvoiceAdjustMasterService
    {
        private readonly IExportInvoiceAdjustMasterRepository exportInvoiceAdjustMasterRepository;
        private readonly IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService;
        private readonly IVoucherRepository voucherRepository;
        public ExportInvoiceAdjustMasterService(IExportInvoiceAdjustMasterRepository exportInvoiceAdjustMasterRepository, IVoucherRepository voucherRepository
            , IEM_PIM_PACKINGINVOICE_MASTERService em_PIM_PACKINGINVOICE_MASTERService)
        {
            this.exportInvoiceAdjustMasterRepository = exportInvoiceAdjustMasterRepository;
            this.voucherRepository = voucherRepository;
            this.em_PIM_PACKINGINVOICE_MASTERService = em_PIM_PACKINGINVOICE_MASTERService;
        }

        public async Task<RResult> GenerateAdjustNumber(int CompanyID)
        {
            return await exportInvoiceAdjustMasterRepository.GenerateAdjustNumber(CompanyID);
        }

        public async Task<List<ExportInvoiceAdjustmentListViewModel>> GetExportInvoiceAdjustmentList(ExportInvoiceAdjustmentListViewModel model)
        {
            return await exportInvoiceAdjustMasterRepository.GetExportInvoiceAdjustmentList(model);
        }

        public async Task<RResult> SaveExportInfoiceAdjustment(ExportInvoiceAdjustMasterViewModel _model)
        {
          
                RResult rResult = new RResult();
                ExportInvoiceAdjustMaster dbModel = new ExportInvoiceAdjustMaster();
                var model = await AddInvoiceOrder(_model);
                var _voucherAmount = await voucherRepository.GetVoucherdetailAsync(v => v.VoucherId == model.VoucherID && v.Amount > 0);
                var voucherAmount = _voucherAmount.Sum(b => b.Amount);
                var modelAmont = model.ExportInvoiceAdjustDetails.Sum(b => b.Amount);
                if (voucherAmount == modelAmont)
                {
                    var generateNumber = await exportInvoiceAdjustMasterRepository.GenerateAdjustNumber((int)model.CompanyID);
                    dbModel.AdjustmentNo = generateNumber.statusMsg;
                    dbModel.AdjustmentSerial = generateNumber.statusCode;
                    dbModel.CreateBY = model.CreateBy;
                    dbModel.CreatedDate = DateTime.Now;
                    dbModel.VoucherID = model.VoucherID;

                    foreach (var d in model.ExportInvoiceAdjustDetails)
                    {
                        ExportInvoiceAdjustDetails details = new ExportInvoiceAdjustDetails();
                        details.Amount = d.Amount;
                        details.PackingInvoiceID = d.PackingInvoiceID;
                        details.OrderID = d.OrderID;
                        details.StyleID = d.StyleID;
                        dbModel.ExportInvoiceAdjustDetails.Add(details);
                    }


                    rResult = await exportInvoiceAdjustMasterRepository.SaveExportInfoiceAdjustment(dbModel);
                    return rResult;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "Amount Overflow.";
                }
                return rResult;
             
        }


        private async Task<ExportInvoiceAdjustMasterViewModel> AddInvoiceOrder(ExportInvoiceAdjustMasterViewModel model)
        {
            var invoiceOrderList = await em_PIM_PACKINGINVOICE_MASTERService.GetInvoiceOrder((int)model.CompanyID, 0);
            foreach (var inv in model.ExportInvoiceAdjustDetails)
            {
                var invoiceId = inv.PackingInvoiceID;
                var orderInfo = invoiceOrderList.Where(b => b.InvoiceID == invoiceId && b.OrderID==inv.OrderID && b.IsAdjustmentInvoice == 0).FirstOrDefault();
                if (orderInfo != null)
                {
                    inv.OrderID = orderInfo.OrderID;
                    orderInfo.IsAdjustmentInvoice += 1;
                }
                if(orderInfo == null)
                {
                    string resultError = "";
                    var _invoiceNo = invoiceOrderList.Where(b => b.InvoiceID == inv.PackingInvoiceID).FirstOrDefault();
                    if (_invoiceNo != null)
                    {
                        resultError = _invoiceNo.EPIM_INVOICENO;
                    }
                    var _orderNo = invoiceOrderList.Where(b => b.InvoiceID == inv.PackingInvoiceID && b.OrderID==inv.OrderID).FirstOrDefault();
                    if(_orderNo == null)
                    {
                        if (resultError.Length > 0)
                        {
                            resultError += $" or";
                        }
                        resultError += _orderNo.OrderNo;
                    }
                    resultError += " is overflow limit.";
                    throw new Exception(resultError);
                }
                if( orderInfo !=null &&  orderInfo.IsAdjustmentInvoice>orderInfo.TotalInvoiceOrder)
                {
                    throw new Exception(orderInfo.EPIM_INVOICENO+ "=>  Overflow invoice limit.");
                }
            }

            return model;
        }
    }
}
