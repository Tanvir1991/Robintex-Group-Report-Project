using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CMBL_SampleGateReceivingViewModel
    {
        public int SampleRecID { get; set; }
        public DateTime DocumentDate { get; set; }
        public long SupplierID { get; set; }
        public long SampleNo { get; set; }
        public DateTime? SampleCreationDate { get; set; }
        public long SampleID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string Deleted { get; set; }
        public long? SampleRecNo { get; set; }
        public string DeliveryChallano { get; set; }
        public DateTime? DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNumber { get; set; }
        public string SupplierName { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public List<CMBL_SampleItemGateReceivingViewModel> CMBL_SampleItemGateReceiving { get; set; }
    }
}
