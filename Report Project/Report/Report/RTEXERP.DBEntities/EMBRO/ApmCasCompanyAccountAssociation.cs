using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmCasCompanyAccountAssociation
    {
        public int CasId { get; set; }
        public int? CasCompany1Id { get; set; }
        public int? CasCompany1Accountid { get; set; }
        public int? CasCompany2Id { get; set; }
        public int? CasCompany2Accountid { get; set; }
    }
}
