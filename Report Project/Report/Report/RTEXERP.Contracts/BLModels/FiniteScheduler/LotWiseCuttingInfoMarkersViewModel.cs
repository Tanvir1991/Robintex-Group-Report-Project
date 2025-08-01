using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class LotWiseCuttingInfoMarkersViewModel
    {
        public long CuttingInfoMarkersID { get; set; }
        public long CuttingInfoID { get; set; }
        public int? MarkerSerial { get; set; }
        public string MarkerName { get; set; }
        public int CuttingLengthYard { get; set; }
        public int CuttingLengthInch { get; set; }
        public int CADMarkerLengthYard { get; set; }
        public int CADMarkerLengthInch { get; set; }
        public int CuttingLayer { get; set; }
        public string ReceivedDIA { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public  List<LotWiseCuttingInfoMarkersSizesViewModel> LotWiseCuttingInfoMarkersSizes { get; set; }
        public decimal CuttingTargetValue { get; set; }
        public decimal SewingInputValue { get; set; }
        public decimal TargetAsCADCons { get; set; }
    }
}
