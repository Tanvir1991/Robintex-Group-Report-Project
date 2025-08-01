using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.EMBRO
{
   public class tbl_Currency_Detail
    {
       public decimal?     RateInPakRs { get; set; }
        [Key]
          public DateTime?  Date { get; set; }
        public long?  EnteredBy { get; set; }
        public long        CurId { get; set; }
    }
}
