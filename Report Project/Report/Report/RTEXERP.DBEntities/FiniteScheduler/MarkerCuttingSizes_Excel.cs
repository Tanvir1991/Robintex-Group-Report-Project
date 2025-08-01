using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class MarkerCuttingSizes_Excel
    {
        [Key]
        public long MCSizesID { get; set; }
        [ForeignKey("MarkerCuttingInfo_Excel")]
        public long MCInfoID { get; set; }
        public int SizeSerial { get; set; }
        public string Size { get; set; }
        public int SizeValue { get; set; }
        public virtual MarkerCuttingInfo_Excel MarkerCuttingInfo_Excel { get; set; }
    }
}
