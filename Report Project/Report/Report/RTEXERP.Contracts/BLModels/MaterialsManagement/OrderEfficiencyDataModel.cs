using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class OrderEfficiencyDataModel
    {
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public int StyleID { get; set; }
        public int LineID { get; set; }
        public string LineName { get; set; }
        public string PantoneNo { get; set; }
        public int HourlyTargetProduction { get; set; }
        public decimal TargetEffiency { get; set; }
        public int? ManPower { get; set; }
        public decimal OrderSMV { get; set; }
        public string Remarks { get; set; }
    }
}
