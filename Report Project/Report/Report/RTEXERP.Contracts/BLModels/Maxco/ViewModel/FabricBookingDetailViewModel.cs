using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class FabricBookingDetailViewModel
    {
        public FabricBookingDetailViewModel()
        {
            FabricBookingSizeDetail = new List<FabricBookingSizeDetailViewModel>();
        }
        public int BookingDetailID { get; set; }
        public int StyleID { get; set; }
        public string StyleName { get; set; }
        public string PantoneNo { get; set; }
        public string FabricComposition { get; set; }
        public double Dia { get; set; }
        public int GSM { get; set; }
        public int FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public int GmtQuantity { get; set; }
        public int NumberOfGarments { get; set; }
        public double Consumption { get; set; }
        public double TotalKG { get; set; }
        public string UseIn { get; set; }
        public string   WashType { get; set; }
        public string Instructions { get; set; }
        public int FSTypeID { get; set; }
        public string FSType { get; set; }
        public int RequirementSheetID { get; set; }
        public int KRS_MID { get; set; }
        public int ProcurementUnitID { get; set; }
        public string ProcurementUnit { get; set; }
        public long AttributeInstanceID { get; set; }
        public List<FabricBookingSizeDetailViewModel> FabricBookingSizeDetail { get; set; }
    }
}
