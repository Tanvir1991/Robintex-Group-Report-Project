using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class MuMenuItem
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public int MenuId { get; set; }
        public int? PageId { get; set; }
        public int OrderId { get; set; }
        public int? LevelId { get; set; }
        public int? ParentMenuItemId { get; set; }
    }
}
