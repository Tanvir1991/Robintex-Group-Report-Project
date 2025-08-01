using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Trim_Setup
    {
        [Key]
        public byte ID { get; set; }
        public string Description { get; set; }
        public byte TrimCategoryID { get; set; }
        public string HomePage { get; set; }
        public bool IsDisplay { get; set; }
        public string DisplayPage { get; set; }
        public int? MRPItemCode { get; set; }
        public bool? IsGreigeTrim { get; set; }
        public bool? IsGenericTrim { get; set; }
        public int? TrimIndex { get; set; }
        public string Abbrievation { get; set; }
        public int? TrimTypeID { get; set; }
    }
}
