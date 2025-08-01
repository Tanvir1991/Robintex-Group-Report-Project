using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class Mer_StylePODetailVM
    {
        public Mer_StylePODetailVM()
        {
            Mer_StylePOColorSizeQuantityDetail = new List<Mer_StylePOColorSizeQuantityDetailVM>();
        }
        public int StyleMasterID { get; set; }        
        public string PONumber { get; set; }
        public string OrderNo { get; set; }
        public decimal? FOB { get; set; }
        public string ExFactoryDate { get; set; }
        public List<Mer_StylePOColorSizeQuantityDetailVM> Mer_StylePOColorSizeQuantityDetail { get; set; }
    }
}
