using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Models
{
   
    public class LoginViewModel
    {
        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [MaxLength(50, ErrorMessage = "Maximam Length 50.")]
        [MinLength(3, ErrorMessage = "Minimum 3 .")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
