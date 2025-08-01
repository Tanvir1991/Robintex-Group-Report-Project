using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CompanyInfo
    {
        public decimal CompanyId { get; set; }
        public string Companyname { get; set; }
        public string Ntn { get; set; }
        public string Stn { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public virtual BasicCoa Company { get; set; }
    }
}
