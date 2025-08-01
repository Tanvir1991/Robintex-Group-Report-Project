using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Valuators
    {
        public string ValuatorCompany { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public int? AssetCoaid { get; set; }
        public int ValuatorId { get; set; }
        public int? ClassId { get; set; }
    }
}
