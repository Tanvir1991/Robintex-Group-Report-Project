using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class MER_Zone
    {
        [Key]
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
    }
}
