using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class Tbl_Cutting_Defect_LotViewModel
    {
        public int ID { get; set; }
        [Display(Name ="Lot No")]
        public int LotID { get; set; }
        public string LotNo { get; set; }
        [Display(Name = "Reject Received KG")]
        public decimal LotReceivedKG { get; set; }
        [Display(Name = "Challan No")]
        public string ChallanNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateMsg { get; set; }
        public List<SelectListItem> LotList { get; set; }
    }
}
