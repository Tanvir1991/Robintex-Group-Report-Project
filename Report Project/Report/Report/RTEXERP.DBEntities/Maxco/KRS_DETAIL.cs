using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class KRS_DETAIL
    {

        [Key]
        public int ID { get; set; }
        public int KRS_MID { get; set; }
        public int FABID { get; set; }
        public int TYPEID { get; set; }
        public int QUALITYID { get; set; }
        public string FAB_COMPOSITION { get; set; }
        public int GSM { get; set; }
        public int GAUGE { get; set; }
        public double FINISHED_WIDTH { get; set; }
        public int ISSPANDEX { get; set; }
        public int? DYEINGID { get; set; }
        public int? KnitType { get; set; }
        public decimal? WSTG { get; set; }
        public string WSTGD { get; set; }
        public int? DyLevel { get; set; }

    }
}
