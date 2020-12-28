using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDW2Project.CustomController;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class LogininController : LoginManagerController
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAccount> _signInManager;
        public LogininController(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            LoginViewModel model = new LoginViewModel();
            model.externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            model.externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var loginUser = await _signInManager.PasswordSignInAsync(model.email, model.password, isPersistent: model.rememberMe, false);
                if (loginUser.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.email);
                    if (user.EmailConfirmed)
                    {
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "You have not verified your email");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email or password is invalid");
                }
            }
            return View(model);
        }
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Loginin");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack()
        {
            LoginViewModel model = new LoginViewModel();
            model.externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info.Principal.Claims.Any(x => x.Value != null))
            {
                var email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: true, bypassTwoFactor: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(email);
                    if (user.EmailConfirmed)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "You have not verified your email");
                        return View("Index", model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Your account are't register,please check again");
                    return View("Index", model);
                }
            }
            ModelState.AddModelError(string.Empty, "Have some problems, pleas try again");
            return View("Index", model);
        }
    }
}
