using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class MasterPolyBagDimension
    {
        public int Id { get; set; }
        public string Dimension { get; set; }
        public int? Garments { get; set; }
    }
}
