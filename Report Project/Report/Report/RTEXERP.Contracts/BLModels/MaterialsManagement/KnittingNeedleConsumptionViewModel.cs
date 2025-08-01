using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class KnittingNeedleConsumptionViewModel
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string Companyname { get; set; }
        public int MachineNo { get; set; }
        public string ConsumptionDate { get; set; }
        public int DIA { get; set; }
        public string BRAND { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}
