using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Mer_StylePOColorSizeQuantityDetail
    {
        [Key]
        public int ColorSizeQuantityDetailID { get; set; }
        [ForeignKey("Mer_StylePODetail")]
        public int StylePODetailID { get; set; }
        public int PantoneID { get; set; }
        public string PantoneNo { get; set; }
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Mer_StylePODetail Mer_StylePODetail { get; set; }
    }
}
