using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmLrpDetail
    {
        public decimal Lrpid { get; set; }
        public int RentalId { get; set; }

        public virtual CbmLrp Lrp { get; set; }
        public virtual Rentals Rental { get; set; }
    }
}
