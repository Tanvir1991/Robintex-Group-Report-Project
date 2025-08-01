using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AppSecurity
{
   public class AspNetRolesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsSuperAdminRole { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
