using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMS
{
    public class ExportInvoiceForExportVoucher
    {
        public int EPIM_ID { get; set; }
        public string EPIM_NO { get; set; }
        public DateTime? EPIM_DATE { get; set; }
        public string EPIM_INVOICENO { get; set; }
        public DateTime? EPIM_INVOICEDATE { get; set; }
        public string EPIM_LCNO { get; set; }
        public DateTime? EPIM_LCDATE { get; set; }
        public int NumberOfGSP { get; set; }
        public int InsertedInvoice { get; set; }

    }
}
