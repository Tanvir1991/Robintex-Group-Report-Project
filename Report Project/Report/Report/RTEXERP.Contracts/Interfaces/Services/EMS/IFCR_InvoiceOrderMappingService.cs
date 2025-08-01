using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.EMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMS
{
    public interface IFCR_InvoiceOrderMappingService
    {
        Task<RResult> FCR_InvoiceOrderMappingSave(FCR_InvoiceOrderMapping entity, bool? saveChange = true);
        Task<RResult> FCR_InvoiceOrderMappingSave(List<FCR_InvoiceOrderMapping> entity, bool? saveChange = true);
        Task<List<FCR_InvoiceOrderMappingViewModel>> FCR_InvoiceOrderMappingDetail(int InvoiceID);
        Task<List<FCR_InvoiceOrderMappingViewModel>> InvoiceOrderFCRDataValidation(List<FCR_InvoiceOrderMappingViewModel> dataList,string OrderNoXML, int CompanyID);
        Task<List<GSPInvoiceDataModel>> InvoiceOrderMappingValidation(string OrderNoXML, int CompanyID,int ExportServiceTypeID);
    }
}
