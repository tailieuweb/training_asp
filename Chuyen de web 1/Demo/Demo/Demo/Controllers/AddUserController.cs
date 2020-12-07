using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class AddUserController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddUserController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser { Email = model.email, UserName = model.email, FullName = model.fullName };
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.role);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("Index", "ConfirmEmail", new { userId = user.Id, token }, Request.Scheme);
                    bool isSucceed = await EmailConfirmation.SendEmailToUser(model.email, confirmationLink);
                    if (isSucceed)
                    {
                        return RedirectToAction("Index", "ListUser");
                    }
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }
    }
}