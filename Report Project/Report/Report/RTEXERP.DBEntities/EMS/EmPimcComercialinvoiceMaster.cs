using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class EmPimcComercialinvoiceMaster
    {
        public int EpimId { get; set; }
        public string EpimNo { get; set; }
        public DateTime? EpimDate { get; set; }
        public string EpimInvoiceno { get; set; }
        public DateTime? EpimInvoicedate { get; set; }
        public int? EpimLcno { get; set; }
        public DateTime? EpimLcdate { get; set; }
        public int? EpimBankname { get; set; }
        public string EpimShipedfrom { get; set; }
        public string EpimShipedto { get; set; }
        public decimal? EpimAmount { get; set; }
        public int? EpimBuyerid { get; set; }
        public string EpimExportno { get; set; }
        public DateTime? EpimExportdate { get; set; }
        public decimal? EpimAvgPrice { get; set; }
        public string EpimContainerNo { get; set; }
        public string EpimFlightno { get; set; }
        public DateTime? EpimSailingdate { get; set; }
        public long? EpimBaccountid { get; set; }
        public long? EpimCompanyid { get; set; }
    }
}
