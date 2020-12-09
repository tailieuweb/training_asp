using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class UserInterfaceViewModel
    {
        public string fullName { set; get; }
        public string avatar { set; get; }
        public IList<string> roles { set; get; }
    }
}
