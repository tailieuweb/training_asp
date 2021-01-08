using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "You need to enter your email")]
        [EmailAddress(ErrorMessage = "This is not Email format")]
        [DisplayName("Email")]
        public string email { set; get; }
    }
}
