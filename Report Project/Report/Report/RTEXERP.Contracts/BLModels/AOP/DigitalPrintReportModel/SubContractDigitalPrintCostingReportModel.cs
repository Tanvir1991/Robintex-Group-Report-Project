using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel
{
    public class SubContractDigitalPrintCostingReportModel
    {
        public long ReqID { get; set; }
        public string ReqDate { get; set; }
        public long WorkorderNo { get; set; }
        public string Customername { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderQty { get; set; }
        public decimal OrderRate { get; set; }
        public string Design_code { get; set; }
        public decimal ProcessQty { get; set; }
        public string Unit { get; set; }
        public decimal ttlCost { get; set; }
        public decimal ClientRate { get; set; }
        public decimal Profit { get; set; }
        public string Curency { get; set; }
        public double doller_rate { get; set; }
        public string MachineName { get; set; }
        public DateTime Req_Date_AC { get; set; }
    }
}
