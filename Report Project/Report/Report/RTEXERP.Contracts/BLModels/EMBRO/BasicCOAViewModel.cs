using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
 public   class BasicCOAViewModel
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public string AllParentAccName { get; set; }
        public string ImmediateParentAccName { get; set; }
        public string AccName { get; set; }
        public string AccountCode { get; set; }
        public string AccountDetail { get; set; }
        public int? ParentId { get; set; }
        public int LevelId { get; set; }
       public string LevelName { get; set; }
        public DateTime Rdate { get; set; }
        public long? NaturalAccountId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
    }
}
