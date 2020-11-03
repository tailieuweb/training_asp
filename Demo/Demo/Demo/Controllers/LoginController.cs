using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public LoginController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string succeeded)
        {
            ViewBag.succeeded = succeeded;
            LoginViewModel model = new LoginViewModel();
            model.ExteralLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            model.ExteralLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var getUser = await _userManager.FindByNameAsync(model.email);
                if (getUser != null && !getUser.EmailConfirmed && (await _userManager.CheckPasswordAsync(getUser, model.password)))
                {
                    ModelState.AddModelError(string.Empty, "Bạn chưa xác nhận Email");
                    return View(model);
                }else if(getUser == null || !(await _userManager.CheckPasswordAsync(getUser, model.password)))
                {
                    ModelState.AddModelError(string.Empty, "Đăng Nhập chưa chính xác");
                    return View(model);
                }else
                {
                   var result = await _signInManager.PasswordSignInAsync(model.email, model.password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "UserPage");
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Login");
            var properties =  _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            CustomUser user = null;
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "UserPage");
            }else
            {
                if(email != null)
                {
                    if(user == null)
                    {
                        user = new CustomUser {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        var result = await _userManager.CreateAsync(user);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }
                    }
                }
                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "UserPage");
            }
        }
    }
}
