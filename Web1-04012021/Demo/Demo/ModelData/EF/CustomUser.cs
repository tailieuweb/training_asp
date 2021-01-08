using Microsoft.AspNetCore.Identity;

namespace ModelData.EF
{
    public class CustomUser : IdentityUser
    {
        public string FullName { set; get; }
    }
}