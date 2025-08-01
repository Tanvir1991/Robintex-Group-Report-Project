using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricAdjustmentTransferType
    {
        public int FabricAdjustmentTransferTypeID { get; set; }
        public string FabricAdjustmentTransferTypeName { get; set; }
        public string FromTransactionMode { get; set; }
        public string ToTransactionMode { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
