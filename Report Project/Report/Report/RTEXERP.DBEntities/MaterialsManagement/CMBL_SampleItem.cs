using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_SampleItem
    {
        [Key]
        public long SampleItemID { get; set; }
        public long ItemID { get; set; }
        [ForeignKey("CMBL_Sample")]
        public long SampleID { get; set; }
        public int UnitID { get; set; }
        public long RequisitionDetailID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? ConversionRate { get; set; }
       
        public int DeliveryPoint { get; set; }

    }
}
