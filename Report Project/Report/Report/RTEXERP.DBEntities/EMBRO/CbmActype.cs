using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmActype
    {
        public decimal ActypeId { get; set; }
        public string ActypeName { get; set; }
        public string ActypeComments { get; set; }

        public virtual BasicCoa Actype { get; set; }
    }
}
