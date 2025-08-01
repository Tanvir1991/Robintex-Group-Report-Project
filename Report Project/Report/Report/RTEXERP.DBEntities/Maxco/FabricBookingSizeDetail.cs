using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricBookingSizeDetail
    {
        [Key]
        public int BookingSizeID { get; set; }
        [ForeignKey("FabricBookingDetail")]
        public int BookingDetailID { get; set; }
        public int FabricTrimID { get; set; }
        public int KRSDID { get; set; }
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int Len { get; set; }
        public int Wid { get; set; }
        public string PantoneNo { get; set; }
        public int Quantity { get; set; }
        public decimal WeightConsumption { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual FabricBookingDetail FabricBookingDetail { get; set; }
    }
}
