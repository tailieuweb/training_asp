using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelData.EF
{
    public class CustomUser :IdentityUser
    {
        public string FullName { set; get; }
    }
}
