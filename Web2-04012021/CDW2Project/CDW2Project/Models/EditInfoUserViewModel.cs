using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class EditInfoUserViewModel
    {
        [Required(ErrorMessage = "Pls, Enter your full name")]
        [DisplayName("Full Name")]
        [StringLength(24,ErrorMessage = "MaximumLenght is 24 characters")]
        public string fullName { set; get; }
        [DisplayName("Address")]
        public string address { set; get; }
        public string userId { set; get; }
    }
}
