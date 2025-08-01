using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Mer_StylePODetail
    {
        public Mer_StylePODetail()
        {
            Mer_StylePOColorSizeQuantityDetail = new HashSet<Mer_StylePOColorSizeQuantityDetail>();
        }
        [Key]
        public int StylePODetailID { get; set; }
        [ForeignKey("Mer_StyleMaster")]
        public int StyleMasterID { get; set; }
        public string PONumber { get; set; }
        public string OrderNo { get; set; }
        public decimal? FOB { get; set; }
        public DateTime ExFactoryDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Mer_StyleMaster Mer_StyleMaster { get; set; }
        public virtual IEnumerable<Mer_StylePOColorSizeQuantityDetail> Mer_StylePOColorSizeQuantityDetail { get; set; }
    }
}
