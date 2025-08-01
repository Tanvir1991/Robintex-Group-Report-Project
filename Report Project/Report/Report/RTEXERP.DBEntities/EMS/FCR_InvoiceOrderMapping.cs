using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.EMS
{
    public class FCR_InvoiceOrderMapping
    {
        [Key]
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public long OrderID { get; set; }
        public string FCRNo { get; set; }
        public DateTime FCRDate { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
