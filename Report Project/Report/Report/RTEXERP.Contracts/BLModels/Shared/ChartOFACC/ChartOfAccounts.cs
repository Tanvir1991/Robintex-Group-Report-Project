using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Shared.ChartOFACC
{
    public class ChartOfAccounts
    {
        public decimal ID { get; set; }

        public string DESCRIPTION { get; set; }
        public string AccountCode { get; set; }


        public int ParentID { get; set; }
        public int LevelID { get; set; }
        //public int Status { get; set; }
    }
}
