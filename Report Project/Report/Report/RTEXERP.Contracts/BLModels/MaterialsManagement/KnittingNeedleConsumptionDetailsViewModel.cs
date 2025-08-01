using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class KnittingNeedleConsumptionDetailsViewModel
    {
        public int ID { get; set; }
        public int KnittingNeedleConsumptionMasterID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal UnitRate { get; set; }
        public int? KnittingRepairItemCategoryID { get; set; }
        public string KnittingRepairItemCategoryName { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateddDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int BroadGroupOne { get; set; }
        public int BroadGroupTwo { get; set; }
        public int BroadGroupThree { get; set; }
        public string ItemName { get; set; }
    }
}
