using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class UserPageViewModel
    {
        public string email { set; get; }
        public string id { set; get; }
        public List<string> Roles { set; get; }
    }
}
