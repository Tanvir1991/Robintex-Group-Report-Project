using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler.Views
{
    public class vw_SFS_Productionline
    {
        [Key]
        public int LineID { get; set; }
        public string ResourceCategory { get; set; }
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }
        public int FloorID { get; set; }
        public string FloorName { get; set; }

        public string LineName { get; set; }
        public string HRM_SectionName { get; set; }
        public int? HRM_SectionID { get; set; }
    }
}
