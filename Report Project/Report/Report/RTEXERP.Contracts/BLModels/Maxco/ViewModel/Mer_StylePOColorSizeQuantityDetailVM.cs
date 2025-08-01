using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class Mer_StylePOColorSizeQuantityDetailVM
    {
        public int StylePODetailID { get; set; }
        public int PantoneID { get; set; }
        public string PantoneNo { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public string SizeName { get; set; }
        
    }
}
