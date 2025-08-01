using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FabricTrims_Setup
    {
        [Key]
        public short ID { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
    }
}
