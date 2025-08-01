using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OrderColorWiseRejectionBreakdown_ReportViewModel
    {
        public long BreakdownID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public int DefectID { get; set; }
        public string DefectName { get; set; }
        public decimal TotalDefectQty { get; set; }
    }
}
