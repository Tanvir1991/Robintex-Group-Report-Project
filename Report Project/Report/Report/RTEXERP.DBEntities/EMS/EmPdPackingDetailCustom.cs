using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class EmPdPackingDetailCustom
    {
        public int EpdId { get; set; }
        public int EpdEpmId { get; set; }
        public int EpdCartonId { get; set; }
        public string EpdCartonNo { get; set; }
    }
}
