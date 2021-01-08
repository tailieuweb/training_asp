using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        public ConfirmEmailController(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string userId, string token)
        {
            var getUser = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(getUser, token);
            if (!result.Succeeded)
            {
                var errorLink = Url.Action("Index", "ErrorSite");
                return LocalRedirect(errorLink);
            }
            return RedirectToAction("Index", "Loginin");
        }
    }
}
