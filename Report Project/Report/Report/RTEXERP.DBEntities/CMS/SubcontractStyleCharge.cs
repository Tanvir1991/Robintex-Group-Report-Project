using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
    public class SubcontractStyleCharge
    {
        public int ID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
