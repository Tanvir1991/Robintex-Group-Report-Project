using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ErpClearingAgentDetail
    {
        public int AgentDetailId { get; set; }
        public int? AgentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
