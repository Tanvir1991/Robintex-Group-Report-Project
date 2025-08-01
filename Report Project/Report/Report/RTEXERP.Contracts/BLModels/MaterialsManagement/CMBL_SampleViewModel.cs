using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CMBL_SampleViewModel
    {
        public long SampleID { get; set; }
        public long SampleNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ApproxDeliveryDate { get; set; }
        public int UserID { get; set; }
        public int? SupplierID { get; set; }
        public string SampleComments { get; set; }
        public int? CompanyID { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
        public decimal TotalValue { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public int SampleStatus { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? CurrencyID { get; set; }
        
        public virtual List<CMBL_SampleItemViewModel> CMBL_SampleItem { get; set; }
        //public virtual CMBL_SampleReceivingViewModel CMBL_SampleReceiving { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public List<SelectListItem> CurrencyList { get; set; }
        public List<SelectListItem> SampleList { get; set; }
    }
}
