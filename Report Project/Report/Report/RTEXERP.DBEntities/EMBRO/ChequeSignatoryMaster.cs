using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ChequeSignatoryMaster
    {
        public ChequeSignatoryMaster()
        {
            ChequeSignatoryDetail = new HashSet<ChequeSignatoryDetail>();
        }

        public int Id { get; set; }
        public decimal ApprovalLimit { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChequeSignatoryDetail> ChequeSignatoryDetail { get; set; }
    }
}
