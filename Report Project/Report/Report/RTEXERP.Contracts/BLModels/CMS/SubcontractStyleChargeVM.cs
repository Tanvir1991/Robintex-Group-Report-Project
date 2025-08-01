using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
    public class SubcontractStyleChargeVM
    {
        public int ID { get; set; }
        [Required]
        public long OrderID { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public decimal OrderRate { get; set; }


        public List<SelectListItem> DDLOrder { get; set; }

        public List<SubcontractStyleChargeListVM> SubcontractStyleChargeList { get; set; }

    }

    public class SubcontractStyleChargeListVM
    {
        public int ID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderRate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateDateStr { get { return this.CreateDate.HasValue == true ? CreateDate.Value.ToString("dd-MMM-yyyy") : ""; } }
    }
}
