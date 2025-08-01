using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AppSecurity
{
    public class UserRegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [MaxLength(50, ErrorMessage = "Maximam Length 50.")]
        [MinLength(3, ErrorMessage = "Minimum 3 .")]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Role Name")]
        [Required]
        public int RoleId { get; set; }

        public string ReturnUrl { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> ActiveList { get; set; }

    }
}
