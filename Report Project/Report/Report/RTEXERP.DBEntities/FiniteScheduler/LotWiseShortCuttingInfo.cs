using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class LotWiseShortCuttingInfo
    {
        [Key]
        public long ShortCuttingInfoID { get; set; }
        [ForeignKey("LotWiseCuttingInfo")]
        public long CuttingInfoID { get; set; }
        public string Size { get; set; }
        public int SizeSerial { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual LotWiseCuttingInfo LotWiseCuttingInfo { get; set; }

    }
}
