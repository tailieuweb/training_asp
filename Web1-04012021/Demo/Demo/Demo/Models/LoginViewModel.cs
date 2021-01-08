using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn cần phải nhập Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { set; get; }

        [Required(ErrorMessage = "Bạn cần phải nhập password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { set; get; }

        public IList<AuthenticationScheme> ExteralLogins { set; get; }
    }
}