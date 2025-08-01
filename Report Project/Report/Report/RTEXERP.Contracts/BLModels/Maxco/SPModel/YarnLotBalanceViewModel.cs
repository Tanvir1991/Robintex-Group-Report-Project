using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class YarnLotBalanceViewModel
    {
        public string LotNo { get; set; }
        public string YarnCompositionName { get; set; }
        public string YarnCountName { get; set; }
        public int? YarnCountId { get; set; }
        public int? YarnCompositionId { get; set; }
        public DateTime? FirstReceivedDate { get; set; }
        public DateTime? LastReceivedDate { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? PreReceivedQty { get; set; }
        public DateTime? FirstIssuedDate { get; set; }
        public DateTime? LastIssuedDate { get; set; }
        public decimal? IssuedQty { get; set; }
        public decimal? PreviousIssueQty { get; set; }
        public decimal? Balance { get; set; }
        public decimal? TotalReceivedQty { get { return  ReceivedQty+PreReceivedQty; } }
        public decimal? TotalIssueQty { get { return IssuedQty + PreviousIssueQty; } }

        public string FirstIssuedDateStr { get{
                 
                    return this.FirstIssuedDate.HasValue==true? this.FirstIssuedDate.Value.ToString("dd-MMM-yyyy"):string.Empty;
            } }
        public string FirstReceivedDateStr
        {
            get
            {

                return this.FirstReceivedDate.HasValue == true ? this.FirstReceivedDate.Value.ToString("dd-MMM-yyyy") : string.Empty;
            }
        }
         
    }

}
