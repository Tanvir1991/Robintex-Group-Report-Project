using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherConfiguration
{
    public class VoucherGeneralConfiguration
    {
        public string ParameterName { get; set; }
        public long AccountID { get; set; }
        public string AccountName { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }

    }
}
