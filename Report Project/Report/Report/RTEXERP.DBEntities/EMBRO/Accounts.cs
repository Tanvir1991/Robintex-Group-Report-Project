using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
 
    public partial class Accounts
    {
        public decimal CatId { get; set; }
        public string CatName { get; set; }
        public decimal SubcatId { get; set; }
        public string SubcatName { get; set; }
        public decimal Bgid { get; set; }
        public string Bgname { get; set; }
        public decimal Ngid { get; set; }
        public string Ngname { get; set; }
        public decimal Iid { get; set; }
        public string Iname { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
    }
}
