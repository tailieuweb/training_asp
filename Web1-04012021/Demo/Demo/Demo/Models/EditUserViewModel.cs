using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class EditUserViewModel
    {
        public string id { set; get; }

        [DisplayName("Full Name")]
        public string fullName { set; get; }

        [Required(ErrorMessage = "Bạn cần phải nhập Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string email { set; get; }

        [DisplayName("Role")]
        public string newRole { set; get; }

        public string oldRole { set; get; }
    }
}