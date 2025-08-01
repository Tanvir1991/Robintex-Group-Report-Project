using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Shared.ChartOFACC
{
  public  class SupplierWIseCompanyNameViewModel
    {
       public  long SupplierId { get; set; }
        public string Supplier { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string SupplierAndCompany { get; set; }



    }
}
