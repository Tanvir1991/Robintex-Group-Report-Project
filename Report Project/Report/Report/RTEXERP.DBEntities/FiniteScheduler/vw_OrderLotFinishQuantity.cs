using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{    
    public class vw_OrderLotFinishQuantity
    {
        [Key]
        public int OrderID { get; set; }
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public string PantoneNo { get; set; }
        public decimal LotFinishQuantity { get; set; }

        //public decimal LotQuantity { get; set; }
        //public int CuttingLengthYard { get; set; }
        //public int CuttingLengthInch { get; set; }
        //public int CuttingLayer { get; set; }
        //public long MCInfoID { get; set; }
        //public string CuttingReportingDate { get; set; }
        //public bool HasShortCutting { get; set; }        
    }
}
