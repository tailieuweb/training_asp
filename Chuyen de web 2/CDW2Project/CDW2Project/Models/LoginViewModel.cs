using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You need to add Email")]
        [EmailAddress(ErrorMessage = "This is not Email format")]
        [DisplayName("Email")]
        //Email
        public string email { set; get; }
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, input password")]
        [DisplayName("Password")]
        //Password
        public string password { set; get; }
        //External login
        public IList<AuthenticationScheme> externalLogins { set; get; }
        //Remember me
        [DisplayName("Remember Me")]
        public bool rememberMe { set; get; }
    }
}
