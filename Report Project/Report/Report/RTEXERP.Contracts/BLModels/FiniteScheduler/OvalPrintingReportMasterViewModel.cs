using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OvalPrintingReportMasterViewModel
    {
        public OvalPrintingReportMasterViewModel()
        {
            OvalPrintingReportDetails = new List<OvalPrintingReportDetailsViewModel>();
        }
        public int ID { get; set; }
        [Display(Name ="Date")]
        public DateTime ReportDate { get; set; }
        [Display(Name = "Date From")]
        public string ReportDateMsg { get; set; }
        [Display(Name = "Date To")]
        public decimal OvalPerDayTotalSalary { get; set; }
        public string ReportDateToMsg { get; set; }
        public double TotalPrice { get { return OvalPrintingReportDetails.Sum(b => b.TotalPrice); } }
        public double TotalCost { get { return OvalPrintingReportDetails.Sum(b => b.TotalCost); } }
        public double TotalProfit { get { return OvalPrintingReportDetails.Sum(b => b.TotalProfit); } }
        public int TotalProductionQty { get { return OvalPrintingReportDetails.Sum(b => b.ProductionQty); } }
        public double TotalProfitBDT { get { return OvalPrintingReportDetails.Sum(b => b.TotalProfitBDT); } }
        public double TotalPriceBDT { get { return OvalPrintingReportDetails.Sum(b => b.TotalPriceBDT); } }
        public double TotalCostBDT { get { return OvalPrintingReportDetails.Sum(b => b.TotalCostBDT); } }
        public List<OvalPrintingReportDetailsViewModel> OvalPrintingReportDetails { get; set; }
        public int MonthID { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }
    }
}
