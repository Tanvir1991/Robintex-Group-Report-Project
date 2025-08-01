using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CMBL_SampleItemViewModel
    {
        public long SampleItemID { get; set; }
        public long ItemID { get; set; }
       
        public long SampleID { get; set; }
        public int UnitID { get; set; }
        public long RequisitionDetailID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? ConversionRate { get; set; }
       
        public int DeliveryPoint { get; set; }

        //
        public long IRID { get; set; }
        public long IRCode { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int SupplierID { get; set; }
        public int CompanyID { get; set; }
        public string SupplierName { get; set; }
        public string SampleCreationDate { get; set; }
        public string UnitDescription { get; set; }

    }
}
