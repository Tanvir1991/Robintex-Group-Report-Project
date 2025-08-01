using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_SampleItemGateReceiving
    {
        [Key]
        public int SampleItemRecID { get; set; }
        [ForeignKey("CMBL_SampleGateReceiveing")]
        public int SampleRecID { get; set; }
        public long SampleItemID { get; set; }
        public decimal ReceivedQuantity { get; set; }

    }
}
