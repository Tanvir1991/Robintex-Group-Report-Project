using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel
{
    public class DigitalPrintCostingReportModel
    {
        public DigitalPrintCostingReportModel()
        {
            InHouseDigitalPrintCosting = new List<InHouseDigitalPrintCostingReportModel>();
            SubContractDigitalPrintCosting = new List<SubContractDigitalPrintCostingReportModel>();
        }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public decimal DigitalPrintPerDayTotalSalary { get; set; }
        public decimal InHouseDigitalEarnings { get { return InHouseDigitalPrintCosting.Sum(b => b.Total_Price_order_dol); } }
        public decimal InHouseDigitalCosting { get { return Math.Round(InHouseDigitalPrintCosting.Sum(b => b.Total_COst_BDT / Convert.ToDecimal(b.doller_rate)), 2); } }
        public decimal InHouseDigitalProfit { get { return InHouseDigitalPrintCosting.Sum(b => b.Total_Profit_Dol); } }
        public decimal InHouseDigitalProduction { get { return InHouseDigitalPrintCosting.Sum(b => b.Delivered_Qty); } }


        public decimal SubContractDigitalEarnings { get { return Math.Round(SubContractDigitalPrintCosting.Sum(b => b.ClientRate / Convert.ToDecimal(b.doller_rate)), 2); } }
        public decimal SubContractDigitalCosting { get { return Math.Round(SubContractDigitalPrintCosting.Sum(b => b.ttlCost / Convert.ToDecimal(b.doller_rate)), 2); } }
        public decimal SubContractDigitalProfit { get { return Math.Round(SubContractDigitalPrintCosting.Sum(b => b.Profit / Convert.ToDecimal(b.doller_rate)), 2); } }
        public decimal SubContractDigitalProduction { get { return SubContractDigitalPrintCosting.Sum(b => b.ProcessQty); } }

        public double doller_rate { get { return InHouseDigitalPrintCosting.Count > 0 ? InHouseDigitalPrintCosting.First().doller_rate : SubContractDigitalPrintCosting.Count > 0 ? SubContractDigitalPrintCosting.First().doller_rate : 0; } }
        public decimal TotalEarnings { get { return InHouseDigitalEarnings + SubContractDigitalEarnings; } }
        public decimal TotalCosting { get { return Math.Round(InHouseDigitalCosting + SubContractDigitalCosting, 2); } }
        public decimal TotalProfit { get { return InHouseDigitalProfit + SubContractDigitalProfit; } }


        public List<InHouseDigitalPrintCostingReportModel> InHouseDigitalPrintCosting { get; set; }
        public List<SubContractDigitalPrintCostingReportModel> SubContractDigitalPrintCosting { get; set; }
    }
}
