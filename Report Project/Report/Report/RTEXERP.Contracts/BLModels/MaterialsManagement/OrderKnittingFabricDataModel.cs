using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class OrderKnittingFabricDataModel
    {
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public double? KnittingQunatity { get; set; }
        public double KnittingQunatityWithWastage { get; set; }
        public double KnittingDone { get; set; } //sum of quantity
        public double Balance { get; set; }
    }
}
