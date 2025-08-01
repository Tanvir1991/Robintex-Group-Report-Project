using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class BankContactInfo
    {
        public decimal AccountID { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}
