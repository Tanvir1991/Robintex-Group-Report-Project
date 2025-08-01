using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
    public class Pro_Master
    {
        [Key]
        public long PMasterID { get; set; }
        public long? OrderID { get; set; }
        public long? StyleID { get; set; }
        public long? ColorID { get; set; }
        public long? LineID { get; set; }
        public long? ReportFor { get; set; }
        public long? QualityOperatorID { get; set; }
        public string QualityCardNo { get; set; }
        public string QualityName { get; set; }
        public string QualityDes { get; set; }
        public long UserID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DefaultDate { get; set; }
        public int? ISInhouse { get; set; }
    }
}
