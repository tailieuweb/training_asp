using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class RegisterViewModel
    {
        [StringLength(24, ErrorMessage = "requires minium 24 characters")]
        [DisplayName("UserName")]
        //User Name
        public string userName { set; get; }
        [EmailAddress(ErrorMessage = "This is not Email format")]
        [Required(ErrorMessage = "Require a additional Email")]
        [DisplayName("Email")]
        //Email
        public string email { set; get; }
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, input password")]
        [DisplayName("Password")]
        //Password
        public string password { set; get; }
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, confirm password")]
        [Compare("password", ErrorMessage = "Cofim password is invalid")]
        [DisplayName("Confirm Password")]
        //Confirm password
        public string confirmPassword { set; get; }
        //External register
        public IList<AuthenticationScheme> externalRegister { set; get; }
    }
}
