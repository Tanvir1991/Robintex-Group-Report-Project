using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FS_ColorSet
    {
        [Key]
        public long ID { get; set; }
        public long ReqID { get; set; }
        public long ColorSetID { get; set; }

        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string HTMLCode { get; set; }
        public string VariationColor { get; set; }
        public string VariationColorHTMLCode { get; set; }
    }
}
