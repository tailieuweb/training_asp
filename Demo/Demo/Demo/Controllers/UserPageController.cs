using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserPageController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserPageController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            CustomUser getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var getRole = await _userManager.GetRolesAsync(getUser);
            UserPageViewModel model = new UserPageViewModel();
            model.id = getUser.Id;
            model.email = User.Identity.Name;
            model.Roles = getRole.ToList();
            return View(model);
        }
    }
}