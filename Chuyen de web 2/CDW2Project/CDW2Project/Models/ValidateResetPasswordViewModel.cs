using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class ValidateResetPasswordViewModel
    {
        [Required(ErrorMessage = "You need to enter your code")]
        [DisplayName("Validated Code")]
        public string code { set; get; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$",ErrorMessage = "The password must be 1 at least upper,lower and digit characters")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, input password")]
        [DisplayName("New Password ")]
        //Password
        public string newPassword { set; get; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$", ErrorMessage = "The password must be 1 at least upper,lower and digit characters")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, confirm password")]
        [Compare("newPassword", ErrorMessage = "Cofim password is invalid")]
        [DisplayName("Confirm Password")]
        //Confirm password
        public string confirmPassword { set; get; }
        public string email { set; get; }
    }
}
