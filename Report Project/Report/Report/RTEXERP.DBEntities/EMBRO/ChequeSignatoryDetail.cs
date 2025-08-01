using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ChequeSignatoryDetail
    {
        public int ChequeSignatoryId { get; set; }
        public int SignatoryId { get; set; }

        public virtual ChequeSignatoryMaster ChequeSignatory { get; set; }
        public virtual Signatory Signatory { get; set; }
    }
}
