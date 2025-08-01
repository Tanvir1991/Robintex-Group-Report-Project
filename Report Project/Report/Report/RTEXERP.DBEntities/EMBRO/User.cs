using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class User
    {
        public decimal Id { get; set; }
        public byte SystemDomainId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public string SystemId { get; set; }
        public int? CompId { get; set; }
    }
}
