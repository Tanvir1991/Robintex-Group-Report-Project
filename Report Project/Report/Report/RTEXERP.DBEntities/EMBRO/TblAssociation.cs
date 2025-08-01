using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblAssociation
    {
        public long Id { get; set; }
        public long LibId { get; set; }
        public long AssetId { get; set; }
        public int Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
