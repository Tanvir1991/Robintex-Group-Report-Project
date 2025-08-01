using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class KRS_MASTER
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? GrossStatus { get; set; }
        public string Ref { get; set; }
        public int BYR { get; set; }

    }
}
