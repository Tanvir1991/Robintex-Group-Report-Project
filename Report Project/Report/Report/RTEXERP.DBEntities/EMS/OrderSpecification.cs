using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class OrderSpecification
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string BuyerRef { get; set; }
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string OptionNo { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Season { get; set; }
        public string CustomerGroup { get; set; }
        public string ConstructionType { get; set; }
    }
}
