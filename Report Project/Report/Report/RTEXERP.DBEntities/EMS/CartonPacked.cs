using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class CartonPacked
    {
        public long Id { get; set; }
        public long? CartonId { get; set; }
        public int? Status { get; set; }
        public int? Poid { get; set; }
        public DateTime? PackingDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsEdited { get; set; }
        public string Barcode { get; set; }
        public int? CartonNo { get; set; }
    }
}
