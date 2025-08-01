using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblFdbpPeriodAssociation
    {
        public long AssociationId { get; set; }
        public long? AssociationPeriodId { get; set; }
        public long? AssociationDocumentId { get; set; }
        public DateTime? AssociationDate { get; set; }
    }
}
