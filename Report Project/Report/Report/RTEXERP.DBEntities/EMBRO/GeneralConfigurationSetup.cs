using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class GeneralConfigurationSetup
    {
        public long Id { get; set; }
        public string Parameter { get; set; }
        public long? AccountId { get; set; }
        public long? BusinessId { get; set; }
    }
}
