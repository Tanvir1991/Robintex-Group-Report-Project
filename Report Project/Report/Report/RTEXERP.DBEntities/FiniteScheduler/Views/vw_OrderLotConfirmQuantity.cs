using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler.Views
{
    public class vw_OrderLotConfirmQuantity
    {
        [Key]
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public long PantoneID { get; set; }
        public double LotConfirmQuantity { get; set; }

    }
}
