using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class PersonalUserViewModel
    {
        public string Id { set; get; }
        public string Image { set; get; }
        public string FullName { set; get; }
        public List<ArticleType> articleTypes { set; get; }
    }
}
