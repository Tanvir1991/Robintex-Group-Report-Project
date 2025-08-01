using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class GeneralSetupDetail
    {
        public string SetupId { get; set; }
        public string InstanceId { get; set; }
        public int CompanyId { get; set; }
        public string InstanceValue { get; set; }
        public string Description { get; set; }
        public DateTime Rdate { get; set; }
    }
}
