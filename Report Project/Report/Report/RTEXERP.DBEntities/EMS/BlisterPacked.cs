using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class BlisterPacked
    {
        public int Id { get; set; }
        public int? BlisterId { get; set; }
        public int? Status { get; set; }
        public int? Poid { get; set; }
        public DateTime? PackingDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsEdited { get; set; }
        public string Barcode { get; set; }
        public int? BlisterNo { get; set; }
        public int? CartonId { get; set; }
    }
}
