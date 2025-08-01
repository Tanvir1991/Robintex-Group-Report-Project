using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class PoassortmentDetail
    {
        public int Id { get; set; }
        public long? Poid { get; set; }
        public long? SizeSetId { get; set; }
        public long? ColorSetId { get; set; }
        public int? NoOfGarments { get; set; }
        public int? PackingTypeId { get; set; }
    }
}
