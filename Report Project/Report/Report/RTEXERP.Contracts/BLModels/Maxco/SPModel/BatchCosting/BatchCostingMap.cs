using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting
{
  public  class BatchCostingMap
    {
        public BatchCostingMap()
        {
            BatchProduction = new List<BatchOrderCost>();
            ShadeProductionCost = new List<BatchOrderCost>();
            SampleProductionCost = new List<BatchOrderCost>();
            MachineWashCost = new List<BatchOrderCost>();
        }
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }

        public int OrderID { get; set; }
        public double CurrencyRate { get; set; }
        public string StoreLocation { get; set; }

        public List<SelectListItem> ddlCompany { get; set; }

        public List<BatchOrderCost> BatchProduction { get; set; }
        public List<BatchOrderCost> ShadeProductionCost { get; set; }
        public List<BatchOrderCost> SampleProductionCost { get; set; }
        public List<BatchOrderCost> MachineWashCost { get; set; }        

        public List<MonthlyBatchCost> MonthlyCostSummary { get; set; }
        public decimal ComPerDayTotalSalary { get; set; }
        [Display(Name ="Month Name")]
        public int MonthID { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }
        public int DateDifferenceDays(DateTime StartDate,DateTime EndDate)
        {
            int dayDifference = Convert.ToInt32((EndDate - StartDate).TotalDays);
            return Math.Abs(dayDifference);
        }
    }
}
