using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class IE_OrderEfficiency
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int StyleID { get; set; }
        public DateTime ReportDate {get;set;}
        public int LineID { get; set; }
        public string PantoneNo { get; set; }
        public int HourlyTargetProduction { get; set; }
        public decimal TargetEffiency { get; set; }
        public decimal OrderSMV { get; set; }
        public decimal? WorkingHour { get; set; }
        public int? LineManpower { get; set; }
        public string Remarks { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
