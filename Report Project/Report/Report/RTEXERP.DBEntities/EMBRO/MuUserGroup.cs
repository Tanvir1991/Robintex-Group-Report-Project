using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class MuUserGroup
    {
        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public int? MenuId { get; set; }
    }
}
