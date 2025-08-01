using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmParameters
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public int CompanyId { get; set; }
    }
}
