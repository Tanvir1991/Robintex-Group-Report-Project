using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OrderWiseMarkerInfoViewModel
    {
        public long MCPMasterID { get; set; }
        public long MCInfoID { get; set; }
        public string Marker { get; set; }
        public int MarkerSerial { get; set; }
        public int ReceivedDIA { get; set; }
        public List<MarkerSizeInfoViewModel> MarkerSizeInfo { get; set; }
    }

    public class MarkerSizeInfoViewModel
    {
        public int SizeSerial { get; set; }
        public string Size { get; set; }
        public int SizeValue { get; set; }
    }
}
