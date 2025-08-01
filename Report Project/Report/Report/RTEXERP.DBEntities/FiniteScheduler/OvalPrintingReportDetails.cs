using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class OvalPrintingReportDetails
    {
        public int ID { get; set; }
        [ForeignKey("OvalPrintingReportMaster")]
        public int MasterID { get; set; }
        public string MachineCode { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string Color { get; set; }
        public string PrintItem { get; set; }
        public int OrderQty { get; set; }
        public int ProductionQty { get; set; }
        public double PrintPricePerDozen { get; set; }
        public double CostPerDozen { get; set; }
        public double ProfitPerDozen { get; set; }
        public double TotalPrice { get; set; }
        public double TotalCost { get; set; }
        public double TotalProfit { get; set; }
        public double TotalPriceBDT { get; set; }
        public double TotalCostBDT { get; set; }
        public double TotalProfitBDT { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual OvalPrintingReportMaster OvalPrintingReportMaster { get; set; }
    }
}
