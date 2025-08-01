using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class BarcodeStatus
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
    }
}
