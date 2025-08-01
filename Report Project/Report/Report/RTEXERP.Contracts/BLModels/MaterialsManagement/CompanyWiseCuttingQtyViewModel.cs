using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CompanyWiseCuttingQtyViewModel
    {
        public DateTime ProductionDate { get; set; }
        public string CompanyName { get; set; }
        public int CuttingQuantity { get; set; }
        public int InspectionQuantity { get; set; }
        public int PassQuantity { get; set; }
        public string CompanyShortName { get; set; }
    }
}
