using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AOP.ReportModel
{

    public class AOPCostingSPData
    {
        public AOPCostingSPData()
        {
            AOPCostingReport = new List<AOPCostingReportModel>();
            //AOPList = new List<AOPCostingReportModel>();
            //CPBList = new List<AOPCostingReportModel>();
        }
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public decimal AopPerDayTotalSalary { get; set; }

        public string Address { get; set; }

        public decimal AOPEarnings { get { return AOPList.Sum(b => b.Total_Price_order_dol); } }
        public decimal AOPCosting { get { return Math.Round(AOPList.Sum(b =>b.Total_COst_BDT/Convert.ToDecimal(b.doller_rate) ),2); } }
        public decimal AOPProfit { get { return AOPList.Sum(b => b.Total_Profit_Dol); } }

        public decimal CPBEarnings { get { return CPBList.Sum(b => b.Total_Price_order_dol); } }
        public decimal CPBCosting { get { return Math.Round(CPBList.Sum(b => b.Total_COst_BDT / Convert.ToDecimal(b.doller_rate)),2); } }
        public decimal CPBProfit { get { return CPBList.Sum(b => b.Total_Profit_Dol); } }

        public decimal DigitalEarnings { get { return DigitalList.Sum(b => b.Total_Price_order_dol); } }
        public decimal DigitalCosting { get { return Math.Round(DigitalList.Sum(b => b.Total_COst_BDT / Convert.ToDecimal(b.doller_rate)), 2); } }
        public decimal DigitalProfit { get { return DigitalList.Sum(b => b.Total_Profit_Dol); } }

        public decimal TotalEarnings { get { return AOPCostingReport.Sum(b => b.Total_Price_order_dol); } }
        public decimal TotalCosting { get { return Math.Round(AOPCostingReport.Sum(b => b.Total_COst_BDT / Convert.ToDecimal(b.doller_rate)),2); } }
        public decimal TotalProfit { get { return AOPCostingReport.Sum(b => b.Total_Profit_Dol); } }
                
        public decimal AOPProduction { get { return AOPList.Sum(b => b.Delivered_Qty); } }
        public decimal CPBProduction { get { return CPBList.Sum(b => b.Delivered_Qty); } }
        public decimal DigitalProduction { get { return DigitalList.Sum(b => b.Delivered_Qty); } }

        public decimal TotalProduction { get { return AOPCostingReport.Sum(b => b.Delivered_Qty); } }
                
        public double doller_rate { get { return AOPCostingReport.Count>0? AOPCostingReport.First().doller_rate:0; } }
        public List<AOPCostingReportModel> AOPCostingReport { get; set; }
        public List<AOPCostingReportModel> AOPList { get { return AOPCostingReport.Where(b => b.LotType == "AOP").ToList(); } }
        public List<AOPCostingReportModel> CPBList { get { return AOPCostingReport.Where(b => b.LotType == "CPB").ToList(); } }
        public List<AOPCostingReportModel> DigitalList { get { return AOPCostingReport.Where(b => b.LotType == "Digital").OrderBy(b=>b.MachineName).ToList(); } }
        public int MonthID { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }

    }
    public class AOPCostingReportModel
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
    }
}
