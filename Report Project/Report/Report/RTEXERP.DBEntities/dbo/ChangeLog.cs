using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class ChangeLog
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
