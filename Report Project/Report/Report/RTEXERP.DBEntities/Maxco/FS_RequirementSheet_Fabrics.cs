using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
   public class FS_RequirementSheet_Fabrics
    {
        [Key]
        public int ID { get; set; }

        public int RequirementSheetID { get; set; }
        public long AttributeInstanceID { get; set; }
        public double RequiredQuantity { get; set; }
        public int? TypeID { get; set; }

        public int? GroupID { get; set; }
        public string PantoneNo { get; set; }
        public int WastagePercent { get; set; }
        public double? BalanceQuantity { get; set; }
        public double? ExtraCut { get; set; }

        public double? CuttingWastage { get; set; }
        public double? DyeingWastage { get; set; }
        public double? KnittingWastage { get; set; }
        public double? WashingWastage { get; set; }
        public double? FinishingWastage { get; set; }

        public double? PrintingWastage { get; set; }
        public double? ConPerPiece { get; set; }
        public decimal? GAQty { get; set; }
        public double? WastagePer { get; set; }
        public int? ProcurementUnitID { get; set; }
        public int? FinishFabricCodeID { get; set; }
    }
}
