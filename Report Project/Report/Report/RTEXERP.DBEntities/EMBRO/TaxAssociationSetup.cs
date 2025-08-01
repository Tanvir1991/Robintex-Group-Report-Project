using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TaxAssociationSetup
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TaxTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}
