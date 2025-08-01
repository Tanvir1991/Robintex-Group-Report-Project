using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class OvalPrintingReportMaster
    {
        public OvalPrintingReportMaster()
        {
            OvalPrintingReportDetails = new HashSet<OvalPrintingReportDetails>();
        }
        public int ID { get; set; }
        public DateTime ReportDate { get; set; }
       public bool IsRemoved { get; set; }
       public DateTime? UpdateDate { get; set; }
       public DateTime? CreateDate { get; set; }
 
        public ICollection<OvalPrintingReportDetails> OvalPrintingReportDetails { get; set; }
    }
}
