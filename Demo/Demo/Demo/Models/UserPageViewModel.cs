using System.Collections.Generic;

namespace Demo.Models
{
    public class UserPageViewModel
    {
        public string email { set; get; }
        public string id { set; get; }
        public List<string> Roles { set; get; }
    }
}