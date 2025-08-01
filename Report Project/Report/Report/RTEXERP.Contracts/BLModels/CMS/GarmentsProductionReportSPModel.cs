using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
    public class GarmentsProductionReportSPModel
    {
        public GarmentsProductionReportSPModel()
        {
            RcvQty = 0;
            Ttl_Ok_Qty = 0;
        }
        public int ISInhouse { get; set; }
        public string ProductionType { get; set; }
        public string ProductionDate { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string PantoneNo { get; set; }
        public int LineID { get; set; }
        public string LineName { get; set; }
        public int? RcvQty { get; set; }
        public int? ALterQty { get; set; }
        public int? SpotQty { get; set; }
        public int? RejectQty { get; set; }
        public int? Ttl_Ok_Qty { get; set; }
        public decimal CM_PC { get; set; }
        public decimal TotalCMDol { get; set; }
        public decimal TotalCMTk { get; set; }
        public long? StartHour { get; set; }
        public long? EndHour { get; set; }
        public long PRo_ID { get; set; }
        public decimal DollerRate { get; set; }

        public int IsShowSalary { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal LineSalary { get; set; }
        public decimal Line_OT { get; set; }
        public decimal Profit { get; set; }

        public int LineGroup { get; set; }
        public decimal StyleSubContractRate { get; set; }
        public decimal StyleSubContractAmount { get; set; }

        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int FloorID { get; set; }
        public string FloorName { get; set; }

        public decimal QuotationCM { get; set; }

        public decimal CMDiff { get; set; }

        public decimal TotalQuotationCM_DOL { get; set; }
        public decimal TotalQuotationCM_Tk { get; set; }
        public long WorkingHour { get; set; }
        public int HourlyTargetProduction { get; set; }
        public long TargetQuantity { get; set; }
        public decimal TargetEffiency { get; set; }
        public decimal TargetCuttingPercent { get; set; }
        public decimal AchiveEfficiency { get; set; }
       public int  LineManpower { get; set; }
        public int IsOutSideOrder { get; set; }

    }


    public class GarmentsProductionData
    {
        public GarmentsProductionData()
        {
            InhouseGarmentsProductionList = new List<GarmentsProductionReportSPModel>();
            SubContractGarmentsProductionList = new List<GarmentsProductionReportSPModel>();
            ProductionLineEmployee = new List<ProductionLineEmployee>();
            OutSideOrderProductionList = new List<GarmentsProductionReportSPModel>();
        }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int ReportFor { get; set; }
        public List<GarmentsProductionReportSPModel> InhouseGarmentsProductionList { get; set; }
        public List<GarmentsProductionReportSPModel> SubContractGarmentsProductionList { get; set; }
        public List<GarmentsProductionReportSPModel> OutSideOrderProductionList { get; set; }
        public List<ProductionLineEmployee> ProductionLineEmployee { get; set; }
    }
}
