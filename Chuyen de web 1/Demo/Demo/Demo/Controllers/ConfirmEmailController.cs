using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ConfirmEmailController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string userId, string token)
        {
            var getUser = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(getUser, token);
            if (result.Succeeded)
            {
                var link = Url.Action("Index", "Login", new { succeeded = "Bạn đã xác nhận thành công, vui lòng đăng nhập" });
                return LocalRedirect(link);
            }
            return null;
        }
    }
}