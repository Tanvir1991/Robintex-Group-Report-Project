using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
  public  class OrderKnittingProductionReportPageModel
    {
        public OrderKnittingProductionReportPageModel()
        {
            OrderKnittingProduction = new List<OrderKnittingProductionSPModel>();
            OrderKnittingFabric = new List<OrderKnittingFabricDataModel>();
        }
        public List<OrderKnittingProductionSPModel> OrderKnittingProduction { get; set; }
        public List<OrderKnittingFabricDataModel> OrderKnittingFabric { get; set; }
    }
}
