using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class QRM_OrderSheetFabrics
    {
        public int ID { get; set; }
        public int? MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public double? DyeingRate { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public string FabricComposition { get; set; }
        public int? DyeingID { get; set; }
        public int? GSM { get; set; }
        public decimal? FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public int VersionID { get; set; }
        public double? RequiredQty { get; set; }
        public decimal? AdjustRequiredQty { get; set; }
        public double? UnitConsumption { get; set; }
        public double? SKUCost { get; set; }
        public int? SizeID { get; set; }
        public string SizeDescription { get; set; }
        public int? UnitID { get; set; }
        public string Unit { get; set; }
        public int? ProcurementUnitID { get; set; }
        public double? WastagePercent { get; set; }
    }
}
