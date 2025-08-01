using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class SFS_ProductionResourceSpecification
    {
        [Key]
        public int SFS_PRSID { get; set; }
        public int SFS_PRTypeID { get; set; }
        public string Name { get; set; }
        public int? IsAllBuyer { get; set; }
        public int? IsAllFabricType { get; set; }
        public int? IsAllGarmentCategory { get; set; }
        public int? IsAllGarmentType { get; set; }
        public byte? FabricCategoryID { get; set; }
        public int? UserID { get; set; }
        public int? HeadUserID { get; set; }
        public string HRM_SectionName { get; set; }
        public int? HRM_SectionID { get; set; }
    }
}
