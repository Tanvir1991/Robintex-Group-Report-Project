using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
   public class Vw_MAC_IndirectCostingItem
    {
        [Key]
    public int CostingItemID { get; set; }
    public int CostingTypeID { get; set; }
    public string CostingType { get; set; }
    public string CostingItem { get; set; }
    public string CssClass { get; set; }
    public int ShowSerial { get; set; }

    }
}
