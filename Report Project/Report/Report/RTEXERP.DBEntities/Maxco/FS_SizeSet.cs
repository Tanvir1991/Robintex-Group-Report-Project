using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FS_SizeSet
    {
        [Key]
        public long ID { get; set; }
        public long FS_ColorSetID { get; set; }

        public long SizeSetID { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }       
    }
}
