using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Areas.Admin.Models
{
    public class EditArticleType
    {
        [Required(ErrorMessage = "You need to article type Id")]
        public string id { set; get; }
        [Required(ErrorMessage = "You need to enter your icon")]
        [DisplayName("Icon")]
        public string icon { set; get; }
        [Required(ErrorMessage = "You need to enter your icon")]
        [StringLength(8, ErrorMessage = "String must be maximum 8 charaters")]
        [DisplayName("Name")]
        public string name { set; get; }

    }
}
