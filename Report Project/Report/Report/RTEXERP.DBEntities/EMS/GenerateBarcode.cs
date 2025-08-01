using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GenerateBarcode
    {
        public long Id { get; set; }
        public int? Poid { get; set; }
        public int? ColorId { get; set; }
        public string ColorName { get; set; }
        public int? SizeId { get; set; }
        public string SizeName { get; set; }
        public string Barcode { get; set; }
        public int? GarmentNo { get; set; }
        public int? Status { get; set; }
        public int? BlisterId { get; set; }
    }
}
