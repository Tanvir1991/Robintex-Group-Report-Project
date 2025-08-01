using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting
{
    public class BatchOrderCost : BatchOrderInfo
    {
        public decimal  FabricQty                {get;set;}
        public long  IRMID                       {get;set;}
        public string IRMCODE { get; set; }
        public double  DyeingRate               {get;set;}
        public double GreyQty                  {get;set;}
        public decimal  DyesCost                 {get;set;}
        public decimal  ChemicalCost             {get;set;}
        public double FinishFabricDelQty       {get;set;}
        public double  FinishFabricQty          {get;set;}
        public string ReqDate { get; set; }
        public DateTime ReportDate { get; set; }
         
    }

    public class MonthlyBatchCost
    {
         public DateTime ReportDate { get; set; }
        public decimal ProductionQuantity { get; set; }
        public decimal ProductionCost { get; set; }

        public decimal SamplingCost { get; set; }
        public decimal MachineWashCost { get; set; }
        public decimal ShadeCorrectionCost { get; set; }
        public decimal TotalProductionCost { get { return ProductionCost + SamplingCost + MachineWashCost + ShadeCorrectionCost; } }
        public decimal Salary { get; set; }
        public decimal TotalCost { get { return TotalProductionCost + Salary; } }
        public decimal Earning { get; set; }
        public decimal GrossProfit { get { return Earning - TotalCost; } }
         
    }
}
