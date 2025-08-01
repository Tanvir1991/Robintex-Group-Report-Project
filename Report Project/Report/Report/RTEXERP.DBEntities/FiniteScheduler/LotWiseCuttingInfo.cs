using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class LotWiseCuttingInfo
    {
        public LotWiseCuttingInfo()
        {
            LotWiseShortCuttingInfo = new List<LotWiseShortCuttingInfo>();
            LotWiseCuttingInfoMarkers = new List<LotWiseCuttingInfoMarkers>();
        }
        [Key]
        public long CuttingInfoID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime CuttingReportingDate { get; set; }
        public int LotID { get; set; }
        public string LotNo { get; set; }
        public string PantoneNo { get; set; }
        public decimal LotQuantity { get; set; }        
        public bool HasShortCutting { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? MarkerCuttingPlanMaster_ExcelID { get; set; }
        public virtual List<LotWiseCuttingInfoMarkers> LotWiseCuttingInfoMarkers { get; set; }
        public virtual List<LotWiseShortCuttingInfo> LotWiseShortCuttingInfo { get; set; }

    }
}
