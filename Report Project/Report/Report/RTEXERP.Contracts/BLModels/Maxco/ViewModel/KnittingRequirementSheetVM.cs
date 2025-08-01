using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
  public  class KnittingRequirementSheetVM
    {
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> OrderList { get; set; }
      //  public List<KRSOrderFabricSPModel> KRSOrderFabric { get; set; }
    }
}
