using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel
{
    public class InHouseDigitalPrintCostingReportModel
    {
        public DateTime LotInspectedDate { get; set; }
        public long orderid { get; set; }
        public string OrderNo { get; set; }
        public long PantoneID { get; set; }
        public string PantoneNo { get; set; }
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public string LotType { get; set; }
        public double aop_price { get; set; }
        public double DyeingRate_min { get; set; }
        public double DyeingRate_max { get; set; }
        public decimal aop_price_main { get; set; }
        public decimal Issued_Qty { get; set; }
        public decimal Delivered_Qty { get; set; }
        public double Price_per_KG_Order { get; set; }
        public decimal Cost_KG_dol { get; set; }
        public decimal Profit_per_KG_Dol { get; set; }
        public decimal Total_COst_BDT { get; set; }
        public decimal Total_cost_BDT_order { get; set; }
        public decimal Total_Price_order_dol { get; set; }
        public double doller_rate { get; set; }
        public decimal Profit_BDT { get; set; }
        public decimal Lot_Income_Dol { get; set; }
        public decimal Total_Profit_Dol { get; set; }
        public string MachineName { get; set; }
        public string Unit { get; set; }
        public DateTime Req_Date_AC { get; set; }
    }
}
