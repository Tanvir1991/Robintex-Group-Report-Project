using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmPaymentModes
    {
        public ApmPaymentModes()
        {
            ApmPaymentModesDetail = new HashSet<ApmPaymentModesDetail>();
        }

        public decimal Mopid { get; set; }
        public string Mopname { get; set; }
        public string Mopdescription { get; set; }

        public virtual ICollection<ApmPaymentModesDetail> ApmPaymentModesDetail { get; set; }
    }
}
