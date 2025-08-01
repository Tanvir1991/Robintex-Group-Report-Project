using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Insurer
    {
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public string RelationsManager { get; set; }
        public string Mobile { get; set; }
        public int? CoaaccountId { get; set; }
        public string Fax { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Type { get; set; }
        public string ContactPerson { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string Email { get; set; }
        public int? InterestAcid { get; set; }
        public int? LongTermLacid { get; set; }
        public decimal? InsuranceAcid { get; set; }
        public int? Companyid { get; set; }
    }
}
