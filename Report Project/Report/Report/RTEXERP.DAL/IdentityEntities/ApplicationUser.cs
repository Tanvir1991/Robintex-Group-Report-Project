using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DAL.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }
        public int CreateBy { get; set; }

       public DateTime CreateDate { get; set; }

        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }


    }
}
