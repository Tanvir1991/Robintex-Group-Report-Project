using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Revaluation
    {
        public decimal? RevaluationId { get; set; }
        public decimal? FixedAssetId { get; set; }
        public DateTime? RevaluationDate { get; set; }
        public float? RevaluationAmount { get; set; }
        public bool? AddSubtract { get; set; }
        public string ValuerName { get; set; }
        public string ValuerExperiance { get; set; }
        public string ValuerQualification { get; set; }
        public string ValuerAddress { get; set; }
        public string ValuerPhone { get; set; }
    }
}
