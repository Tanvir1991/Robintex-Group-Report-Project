using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class Tbl_KnittingMachines
    {
        [Key]
        public int MachineNo { get; set; }
        public int? DIA { get; set; }
        public string BRAND { get; set; }
        public long? CompanyID { get; set; }
        public int? Floor { get; set; }
        public int? Guage { get; set; }
        public string Slength { get; set; }
        public int? Feeder { get; set; }
        public int? rpm { get; set; }
        public int? ycount { get; set; }
        public int? y_type { get; set; }
        public string year { get; set; }
        public string model { get; set; }
        public double? ROD1_Weight { get; set; }
        public double? ROD2_Weight { get; set; }
        public double? ROD3_Weight { get; set; }
        public double? ROD4_Weight { get; set; }
        public double? ROD5_Weight { get; set; }
    }
}
