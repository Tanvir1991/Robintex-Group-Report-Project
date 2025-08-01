using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class PnlAddCogsItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool? IsAddition { get; set; }
        public bool? AssociateWithGruop { get; set; }
        public int? Level { get; set; }
        public int? Periority { get; set; }
        public long? CompanyId { get; set; }
        public long? ParentId { get; set; }
    }
}
