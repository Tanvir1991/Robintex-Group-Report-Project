using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class Collection
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public int BuyerID { get; set; }
        public short GenderID { get; set; }

        public DateTime CreationDate { get; set; }
        public int SeasonID { get; set; }
        public short Status { get; set; }
        public int Year { get; set; }
        public DateTime? AssignedDate { get; set; }
        public int? FabricCategoryID { get; set; }
        public int? DivisionID { get; set; }
    }
}
