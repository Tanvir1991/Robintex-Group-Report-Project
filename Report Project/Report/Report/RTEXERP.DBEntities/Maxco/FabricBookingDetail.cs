using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricBookingDetail
    {
        public FabricBookingDetail()
        {
            FabricBookingSizeDetail = new List<FabricBookingSizeDetail>();
        }
        [Key]
        public int BookingDetailID { get; set; }
        [ForeignKey("FabricBookingMaster")]
        public int BookingMasterID { get; set; }
        public int StyleID { get; set; }
        public string PantoneNo { get; set; }
        public string FabricComposition { get; set; }
        public int Dia { get; set; }
        public int GSM { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public int GmtQuantity { get; set; }
        public decimal Consumption { get; set; }        
        public string UseIn { get; set; }
        public string WashType { get; set; }
        public string Instructions { get; set; }
        public int FSTypeID { get; set; }
        public int RequirementSheetID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int KRS_MID { get; set; }
        public int ProcurementUnitID { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual List<FabricBookingSizeDetail> FabricBookingSizeDetail { get; set; }
        public virtual FabricBookingMaster FabricBookingMaster { get; set; }
    }
}
