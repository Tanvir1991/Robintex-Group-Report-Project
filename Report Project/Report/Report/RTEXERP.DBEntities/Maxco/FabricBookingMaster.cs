using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricBookingMaster
    {
        public FabricBookingMaster()
        {
            FabricBookingDetail = new List<FabricBookingDetail>();
        }
        [Key]

        public int BookingMasterID { get; set; }
        [ForeignKey("FabricBooking")]
        public int FabricBookingID { get; set; }
        public int Version { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        public DateTime DeliveryStartDate { get; set; }
        public DateTime DeliveryEndDate { get; set; }
        public string SpecialInstruction { get; set; }
        public string Reference { get; set; }
        public string RevisionReason { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual List<FabricBookingDetail> FabricBookingDetail { get; set; }
        public virtual FabricBooking FabricBooking { get; set; }
    }
}
