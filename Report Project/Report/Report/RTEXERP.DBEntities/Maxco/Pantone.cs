using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Pantone
    {
        public string PantoneNo { get; set; }
        public string PicturePath { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public char? Type { get; set; }
        public string HTMLCode { get; set; }
        public float? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public string ColorItalCode { get; set; }
        public int? PalleteID { get; set; }
    }
}
