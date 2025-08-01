using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
   public class MonthlyCuttingProductionResponseModel
    {
        public string DateDuration { get; set; }
        public string CurrentDateSTR { get; set; }
        public DateTime CurrentDate { get; set; }

        public int RBLCuttingQty { get; set; }
        public int CBLCuttingQty { get; set; }
        public int TotalCutting { get { return RBLCuttingQty + CBLCuttingQty; } }

        public int RBLInspectionQty { get; set; }
        public int CBLInspectionQty { get; set; }
        public int TotalInspectionQty { get { return RBLInspectionQty + CBLInspectionQty; } }

        public int RBLPassQty { get; set; }
        public int CBLPassQty { get; set; }

        public int TotalPassQty { get { return RBLPassQty + CBLPassQty; } }
        
        public int RBLDefectQty { get { return RBLInspectionQty - RBLPassQty; } }
        public int CBLDefectQty { get { return CBLInspectionQty - CBLPassQty; } }
        public int TotalDefectQty { get { return RBLDefectQty + CBLDefectQty; } }

        public decimal DailySalary { get; set; }
        public decimal CostPerPcsCutting { get {return (RBLCuttingQty + CBLCuttingQty)>0?(DailySalary / (RBLCuttingQty + CBLCuttingQty)):0; } }

    }
}
