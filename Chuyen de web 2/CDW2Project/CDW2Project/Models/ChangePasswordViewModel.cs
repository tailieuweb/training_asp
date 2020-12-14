using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class ChangePasswordViewModel
    {
        public string id { set; get; }
        [Required(ErrorMessage = "Please, enter current password")]
        [DisplayName("Current Password")]
        public string currentPassword { set; get; }
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, input password")]
        [DisplayName("New Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$", ErrorMessage = "At least one uppercase,digit,lowercase and 6 - 12 in length")]
        //Password
        public string newPassword { set; get; }
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Requires more than 6 characters and minimum 12 characters")]
        [Required(ErrorMessage = "Please, confirm password")]
        [Compare("newPassword", ErrorMessage = "Confirm Password is invalid")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$",ErrorMessage = "At least one uppercase,digit,lowercase and 6 - 12 in length")]
        [DisplayName("Confirm Password")]
        //Confirm password
        public string passwordConfirmation { set; get; }
        public bool hasPassword { set; get; }
    }
}
