using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_DocumentType_Setup
    {
        [Key]
        public int DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Initials { get; set; }
    }
}
