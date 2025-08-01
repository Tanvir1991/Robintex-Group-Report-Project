using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Common
{
    public class CommonDropDown
    {
      public List<SelectListItem> YarnStockReportTYpe()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem {Text="Lot Wise",Value="1" });
            selectListItems.Add(new SelectListItem { Text = "Yarn Summary", Value = "2" });
            return selectListItems;
        }

      
    }

    public class MDReportName
    {
        public static string BatchCosting = "Batch Costing";
        public static string AOPCosting = "AOP Costing";
        public static string OvalCosting = "Oval Costing";
        public static string KnittingCosting = "Knitting";
        public static string GarmentsProduction = "Garments Production";
        public static string CuttingCosting = "Cutting";
        public static string DigitalPrint = "Digital Print";

        public static List<MDReportItem> GetReports()
        {
            List<MDReportItem> mDReportItems = new List<MDReportItem>();
            mDReportItems.Add(new MDReportItem {ReportKey= "Batch Costing", ReporFullName="", ReportShowName=""});
            mDReportItems.Add(new MDReportItem { ReportKey = "AOP Costing", ReporFullName = "", ReportShowName = "" });
            mDReportItems.Add(new MDReportItem { ReportKey = "Oval Costing", ReporFullName = "", ReportShowName = "" });
            mDReportItems.Add(new MDReportItem { ReportKey = "Knitting", ReporFullName = "", ReportShowName = "" });
            mDReportItems.Add(new MDReportItem { ReportKey = "Garments Production", ReporFullName = "", ReportShowName = "" });
            mDReportItems.Add(new MDReportItem { ReportKey = "Cutting", ReporFullName = "", ReportShowName = "" });
            mDReportItems.Add(new MDReportItem { ReportKey = "Digital Print", ReporFullName = "", ReportShowName = "" });
            return mDReportItems;
        }
    }


}
