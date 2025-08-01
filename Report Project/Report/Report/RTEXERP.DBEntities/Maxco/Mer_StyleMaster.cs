using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Mer_StyleMaster
    {
        public Mer_StyleMaster()
        {
            Mer_StylePODetail = new HashSet<Mer_StylePODetail>();            
        }
        [Key]
        public int StyleMasterID { get; set; }
        public string Program { get; set; }
        public int BuyerID { get; set; }
       public int ZoneID { get; set; }
       public int SeasonID { get; set; }
       public string StyleNo { get; set; }        
       public bool? IsActive { get; set; }
       public bool? IsRemoved { get; set; }
       public int? CreatedBy { get; set; }
       public DateTime CreatedDate { get; set; }
       public int? UpdatedBy { get; set; }
       public DateTime? UpdatedDate { get; set; }
        public virtual IEnumerable<Mer_StylePODetail> Mer_StylePODetail { get; set; }

    }
}
