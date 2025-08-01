using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FsgSetupDetail
    {
        public int Fsgid { get; set; }
        public int Id { get; set; }
        public string Fid { get; set; }
        public string Description { get; set; }
        public int? Coaid { get; set; }
        public int LevelId { get; set; }
        public string ParentId { get; set; }
        public int IsFormula { get; set; }
        public string FormulaName { get; set; }
        public int? Coasign { get; set; }
        public int IsPrintDesc { get; set; }
        public int IsPrintValue { get; set; }
        public int IsBold { get; set; }
        public int IsCaps { get; set; }
        public int LineFeed { get; set; }
        public int Indent { get; set; }
        public int LineType { get; set; }
        public int IsBox { get; set; }
        public int IsHline { get; set; }
        public int IsVline { get; set; }
    }
}
