using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FS_Fabric_Details
    {
        [Key]
        public int ID { get; set; }
        public int FID { get; set; }
        public int? FabricID { get; set; }
        public int? ColorSetID { get; set; }
        public int? ShellColorSetID { get; set; }
        public int? SizeSetID { get; set; }
        public int? TrimID { get; set; }
    }
}
