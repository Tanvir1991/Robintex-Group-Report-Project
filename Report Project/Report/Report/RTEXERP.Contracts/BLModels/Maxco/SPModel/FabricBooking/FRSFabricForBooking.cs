using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel.FabricBooking
{
    public class FRSFabricForBooking
    {
                                             
        public int RequirementSheetID { get; set; }
        public int KRSID { get; set; }
        public int StyleID { get; set; }
        public string StyleName { get; set; }
        public int NumberOfGarments { get; set; }
        public int RequirementSheetFabricID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int FSTypeID { get; set; }
        public string FSType { get; set; }
        public string FabricComposition { get; set; }
        public double RequiredQuantity { get; set; }
        public int FabricID { get; set; }
        public int GSM { get; set; }
        public double FinishedWidth { get; set; }
        public int FabricColorID { get; set; }
        public string PantoneNo { get; set; }
        public int ProcurementUnitID { get; set; }
        public string Unit { get; set; }
        public int FabricTypeID { get; set; }
        public int FabricQualityID { get; set; }
        public int TrimID { get; set; }
        public string FabricUseIn { get; set; }
        public double FinishFabricConsumption { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
    }
}
