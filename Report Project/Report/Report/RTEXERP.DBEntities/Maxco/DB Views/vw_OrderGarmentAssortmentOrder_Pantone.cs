using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco.DB_Views
{
   public class vw_OrderGarmentAssortmentOrder_Pantone
    {
        public int ID { get; set; }
        public int? StyleID { get; set; }
        public string StyleName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public int? FabricID { get; set; }
        public int SizeSetID { get; set; }
        public string Size { get; set; }
        public int ColorSetID { get; set; }
        public string PantoneNo { get; set; }
        public string PalletType { get; set; }
        public string ColorName { get; set; }
        public int? NumberOfGarments { get; set; }
    }
}
