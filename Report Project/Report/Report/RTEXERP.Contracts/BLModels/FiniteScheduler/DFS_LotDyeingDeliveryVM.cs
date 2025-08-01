using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
   public class DFS_LotDyeingDeliveryVM
    {
        public int ID { get; set; }
        [Required]
        public long LotID { get; set; }
        public string LotNo { get; set; }
        [Required]
        public DateTime LotConfirmDate { get; set; }
        public string Remarks { get; set; }
        public int UserID { get; set; }

        public bool UIDeleted { get; set; }
 
        public List<SelectListItem> DDLLot { get; set; }
        public string LotConfirmDate_STR { get { return LotConfirmDate.ToString("dd-MMM-yyyy"); } }
    }


}
