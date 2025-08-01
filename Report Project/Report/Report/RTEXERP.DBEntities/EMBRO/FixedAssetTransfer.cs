using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FixedAssetTransfer
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public int AssetCoaid { get; set; }
        public int FixedAssetClassId { get; set; }
        public DateTime Rdate { get; set; }
        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
    }
}
