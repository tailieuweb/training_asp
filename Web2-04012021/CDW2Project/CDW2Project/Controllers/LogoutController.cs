using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class LogoutController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        public LogoutController(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Loginin");
        }
    }
}
