using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class AddUserViewModel
    {
        [DisplayName("Full Name")]
        public string fullName { set; get; }

        [Required(ErrorMessage = "Bạn cần phải nhập Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { set; get; }

        [Required(ErrorMessage = "Bạn cần phải nhập password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { set; get; }

        [Required(ErrorMessage = "Bạn cần phải nhập ConfirmedPassword")]
        [Compare("password", ErrorMessage = "Xác nhận password không đúng")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string confirmedPassword { set; get; }

        [DisplayName("Role")]
        public string role { set; get; }
    }
}