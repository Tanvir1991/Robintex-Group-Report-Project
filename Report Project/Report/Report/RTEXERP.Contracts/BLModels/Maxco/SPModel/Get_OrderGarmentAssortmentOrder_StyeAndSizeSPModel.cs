using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class OrderGarmentAssortmentOrder_StyeAndSizeSPModel
    {
        public int OrderStyleID { get; set; }
        public int NumberOfGarments { get; set; }
        public string SizeName { get; set; }
        public int SizeOrder { get; set; }
        public int NumberOfGarmentsWithWastage { get; set; }
        public int StyleNumberOfGarments { get; set; }
    }
}
