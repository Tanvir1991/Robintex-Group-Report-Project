using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Shared.ChartOFACC
{
 public   class SupplierReportViewModel
    {
        public int Id { get; set; }
        public string DateFromStr { get; set; }
        public string DateToStr { get; set; }
        public string SuplierId { get; set; }
        public IEnumerable<SelectListItem> SupplierList { get; set; }
    }
}
