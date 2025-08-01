using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricBooking
    {
        public FabricBooking()
        {
            FabricBookingMaster = new List<FabricBookingMaster>();
        }
        [Key]
        public int FabricBookingID { get; set; }
        public string FabricBookingNo { get; set; }
        public int OrderID { get; set; }
        public int CurrentVersion { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual List<FabricBookingMaster> FabricBookingMaster { get; set; }
    }
}
