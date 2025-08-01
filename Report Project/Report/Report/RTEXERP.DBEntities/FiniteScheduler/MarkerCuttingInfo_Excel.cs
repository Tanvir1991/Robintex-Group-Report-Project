using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class MarkerCuttingInfo_Excel
    {
        public MarkerCuttingInfo_Excel()
        {
            MarkerCurringSizes_Excel = new List<MarkerCuttingSizes_Excel>();
            MarkerCuttingConsumption_Excel = new MarkerCuttingConsumption_Excel();
        }
        [Key]
        public long MCInfoID { get; set; }
        [ForeignKey("MarkerCuttingPlanMaster_Excel")]
        public long MCPMasterID { get; set; }
        public string InfoType { get; set; }
        public int MarkerSerial { get; set; }
        public int Yrd { get; set; }
        public int Inch { get; set; }
        public int DiaInch { get; set; }
        public int GSM { get; set; }
        public decimal RibCollar { get; set; }
        public decimal Dzzn { get; set; }
        public decimal WithWastage { get; set; }
        public string RefNo { get; set; }
        public int MEffi { get; set; }
        public decimal TotalMarkerReq { get; set; }      
        
        public virtual List<MarkerCuttingSizes_Excel> MarkerCurringSizes_Excel { get; set; }
        public virtual MarkerCuttingConsumption_Excel MarkerCuttingConsumption_Excel { get; set; }
        public virtual MarkerCuttingPlanMaster_Excel MarkerCuttingPlanMaster_Excel { get; set; }

    }
}
