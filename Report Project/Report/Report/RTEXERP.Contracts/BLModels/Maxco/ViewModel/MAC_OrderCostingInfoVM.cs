using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class MAC_OrderCostingInfoVM
    {
        public MAC_OrderCostingInfoVM()
        {
            MAC_FabricCostingInfo = new List<MAC_FabricCostingInfoVM>();
            MAC_AccessoriesCostingInfo = new List<MAC_AccessoriesCostingInfoVM>();
        }
        public int ID { get; set; }
        public DateTime CostingDate { get; set; }
        public string Code { get; set; }
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Buyer")]
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        [Display(Name = "Style")]
        public string StyleName { get; set; }
        public int GSM { get; set; }
        
        [Display(Name = "Fabric Type")]
        public int FabricTypeID { get; set; }
        [Display(Name = "Quality")]
        public int? FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        [Display(Name = "Quality")]
        public string FqbricQuality { get; set; }
        [Display(Name = "Order Qty")]
        public int? OrderQuantity { get; set; }
        public decimal SMV { get; set; } = 0;
        public decimal? Efficiency { get; set; }
        public decimal? CPM { get; set; }
        public decimal CBL { get; set; } = 0;
        [Display(Name = "B.C Commission")]
        public decimal BackCalculationPercent { get; set; } = 0;
        [Display(Name = "Fabrics Cons/Dzn")]
        public decimal FabricConsumptionPerDzn { get; set; } = 0;
 
        public int YarnCounID { get; set; }
        public int TrimID { get; set; }

        public decimal TotalFabricCost { get { return MAC_FabricCostingInfo.Sum(b => b.TotalContribution); } }

        public decimal TotalAccessoriesCost { get { return MAC_AccessoriesCostingInfo.Where(b => b.CostingTypeID == 1).Sum(b => b.CostRate); } }

        public string CostingDateSTR { get { return CostingDate.ToString("dd-MMM-yyyy"); } }

        public IEnumerable<SelectListItem> DDLBuyer { get; set; }
        public IEnumerable<SelectListItem> DDLTrim { get; set; }
        public IEnumerable<SelectListItem> DDLQuality { get; set; }
        public IEnumerable<SelectListItem> DDLFabricType { get; set; }
        public IEnumerable<SelectListItem> DDLYarnCount { get; set; }
        public List<MAC_FabricCostingInfoVM> MAC_FabricCostingInfo { get; set; }

        public List<MAC_AccessoriesCostingInfoVM> MAC_AccessoriesCostingInfo { get; set; }
        public List<Vw_MAC_IndirectCostingItem> InderectCostingItemList { get; set; }


    }
}
