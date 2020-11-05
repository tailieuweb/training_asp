using System.Collections.Generic;

namespace Demo.Models
{
    public class ListUserViewModel
    {
        public string id { set; get; }
        public string fullName { set; get; }
        public List<string> roles { set; get; }
        public string email { set; get; }
    }
}