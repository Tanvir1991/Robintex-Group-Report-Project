using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
    public class InstrumentViewModel
    {
        public decimal InstrumentId { get; set; }
        public int InstrumentTypeId { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime ChqDate { get; set; }
        public string ChequeNarration { get; set; }
        public int ChequeSignatoryId { get; set; }
        public decimal ChqAmount { get; set; }
        public int ExportInvoiceTypeID { get; set; }
        public string ExportInvoiceType { get; set; }
        public DateTime VoucherDate { get; set; }
    }
}
