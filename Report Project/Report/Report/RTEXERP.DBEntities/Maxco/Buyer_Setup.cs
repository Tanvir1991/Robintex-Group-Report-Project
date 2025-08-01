using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
   public class Buyer_Setup
    {
        public byte ID { get; set; }
        public string Description { get; set; }
        public string ContactPerson { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string Telno2 { get; set; }
        public string Fax { get; set; }
        public string InspectingAgent { get; set; }
        public string Email { get; set; }
        public string Prefix { get; set; }
        public byte Status { get; set; }
        public int? HeadUser { get; set; }
        public int? CompanyAssoc { get; set; }
        public int? LabDipApproval { get; set; }

    }
}
