using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
   public class MM_MRPItem
    {
        
        [Key]
        public int MRPItemCode { get; set; }
        public string MName { get; set; }
        public int? SKU { get; set; }
        public string PurchaseUnit { get; set; }
        public string IssueUnit { get; set; }
        public bool? IsMandatory { get; set; }
        public bool? IsOperation { get; set; }
        public long? LeadTimeFormulaID { get; set; }
        public long? WastageFormulaID { get; set; }
        public bool? IsDerivedFromCapturing { get; set; }
        public bool? IsRecursive { get; set; }
        public bool? IsRoutable { get; set; }
        public byte? ConversionLevel { get; set; }
        public string OperationName { get; set; }
        public bool? IsCRP { get; set; }
        public bool? IsIOP { get; set; }
        public long? LoadFormulaID { get; set; }
        public bool? IsLateralRouting { get; set; }
        public bool? IsFabric { get; set; }
        public int AgencyID { get; set; }
    }
}
