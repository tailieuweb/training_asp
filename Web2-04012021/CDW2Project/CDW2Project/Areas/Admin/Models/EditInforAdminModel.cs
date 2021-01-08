using Microsoft.AspNetCore.Identity;
using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Areas.Admin.Models
{
    public class EditInforAdminModel
    {
        //Id
        [Required(ErrorMessage = "Some thing wrong with your Id")]
        public string Id { set; get; }
        //fullname
        [Required(ErrorMessage = "You need to enter your full name")]
        [DisplayName("FullName")]
        public string FullName { set; get; }
        //image
        public string Image { set; get; }
        //address
        [Required(ErrorMessage = "You need to enter your address")]
        [DisplayName("Address")]
        public string Address { set; get; }
        //user name
        [DisplayName("UserName")]
        public string UserName { set; get; }
        //new Password
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$", ErrorMessage = "The password must be 1 at least upper,lower and digit characters")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [DisplayName("New Password ")]
        public string newPassword { set; get; }
        //confirm Password
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$", ErrorMessage = "The password must be 1 at least upper,lower and digit characters")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "requires more than 6 characters and minimum 12 characters")]
        [DisplayName("Confirm Password ")]
        public string confirmPassword { set; get; }
        //validate role
        [Required(ErrorMessage = "You need to enter your role")]
        public string validateRole { set; get; }
        public string validateOldRole { set; get; }
        public List<IdentityRole> roles {set;get;}
        public List<Article> ArticlesList { set; get; }
    }
}
