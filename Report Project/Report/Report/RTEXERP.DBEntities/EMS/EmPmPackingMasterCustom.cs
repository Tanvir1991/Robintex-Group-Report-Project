using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class EmPmPackingMasterCustom
    {
        public int EpmId { get; set; }
        public string EpmNo { get; set; }
        public DateTime? EpmDate { get; set; }
        public string EpmInvoiceno { get; set; }
        public DateTime? EpmInvoicedate { get; set; }
        public int? EpmLcno { get; set; }
        public DateTime? EpmLcdate { get; set; }
        public int? EpmBankname { get; set; }
        public string EpmShippedfrom { get; set; }
        public string EpmShippedto { get; set; }
        public string EpmShipmentmode { get; set; }
        public string EpmCountryorigin { get; set; }
        public decimal? EpmNetweight { get; set; }
        public decimal? EpmNetcartonweight { get; set; }
        public int? EpmBuyerid { get; set; }
        public string EpmDestination { get; set; }
        public long? EpmCompanyid { get; set; }
    }
}
