using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Style
    {
        [Key]
        public long ID { get; set; }
        public string Description { get; set; }
        public byte? GarmentID { get; set; }
        public byte? Status { get; set; }
        public DateTime? SamplingDate { get; set; }
        public byte? CapturingStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SeriesID { get; set; }
        public long? ParentStyleID { get; set; }
        public byte? FabricCategoryID { get; set; }
        public long? ParentID { get; set; }
        public string OrderNo { get; set; }
        public int? CollectionID { get; set; }
        public int? UserID { get; set; }
        public int? ProcurementStatus { get; set; }
        public byte IsLocked { get; set; }
        public byte IsDummy { get; set; }
        public bool? GrossStatus { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public byte[] FrontImage { get; set; }
        public byte[] BackImage { get; set; }
        public string ReferenceNo { get; set; }
    }
}
