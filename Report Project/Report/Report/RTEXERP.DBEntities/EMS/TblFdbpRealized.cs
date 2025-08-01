using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblFdbpRealized
    {
        public long Id { get; set; }
        public long? MasterId { get; set; }
        public double? Value { get; set; }
        public double? ConversionRate { get; set; }
        public DateTime? Created { get; set; }
    }
}
