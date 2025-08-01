using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OrderWiseOKAndDefectQuantityViewModel
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal OKQuantity { get; set; }
        public decimal DefectQuantity { get; set; }

    }
}
