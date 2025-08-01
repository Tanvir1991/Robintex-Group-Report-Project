using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class MachineProductionRollSPModel
    {
        public DateTime TransactionDate { get; set; }
        public string Companyname { get; set; }
        public long? CompanyID { get; set; }
        public int MachineNo { get; set; }
        public int? MachineDIA { get; set; }
        public string BRAND { get; set; }
        public int? MachineGuage { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public int? GSM { get; set; }
        public double? Width { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string ShiftCode { get; set; }
        public int? RollID { get; set; }
        public string RollNo { get; set; }
        public double Quantity { get; set; }
        public double QuantityValue { get; set; }
        public decimal DollerRate { get; set; }
    }
}
