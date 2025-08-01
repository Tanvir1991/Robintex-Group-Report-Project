using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class MarkerCuttingPlanMaster_Excel
    {
        public MarkerCuttingPlanMaster_Excel()
        {
            MarkerCuttingInfo_Excel = new List<MarkerCuttingInfo_Excel>();
            MarkerCuttingFabricDetail_Excel = new List<MarkerCuttingFabricDetail_Excel>();
        }
        [Key]
        public long MCPMasterID { get; set; }
       
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string Fabric { get; set; }
        public string FabricQuality { get; set; }
        public int GSM { get; set; }
        public decimal CostedCons { get; set; }
        public string CostedConsUnit { get; set; }
        public decimal SewingInputPercentage { get; set; }
        public int Dia { get; set; }
        public int TotalQty { get; set; }
        public int TotalPetitQty { get; set; }
        public DateTime Date { get; set; }
        public string TOD { get; set; }
        public string Color { get; set; }
        public string CuttingDirection { get; set; }
        public DateTime ExcelUploadDate { get; set; }
        public int? UploadedBy { get; set; }
        public virtual List<MarkerCuttingInfo_Excel> MarkerCuttingInfo_Excel { get; set; }
        public virtual List<MarkerCuttingFabricDetail_Excel> MarkerCuttingFabricDetail_Excel { get; set; }

    }
}
