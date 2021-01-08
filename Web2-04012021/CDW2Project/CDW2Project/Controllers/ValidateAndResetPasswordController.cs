using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class ValidateAndResetPasswordController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        public ValidateAndResetPasswordController(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index([FromQuery] string email)
        {
            if(email != null)
            {
                var user = _userManager.FindByNameAsync(email);
                if (HttpContext.Session.GetString(email) != null && user != null)
                {
                    ValidateResetPasswordViewModel model = new ValidateResetPasswordViewModel();
                    model.email = email;
                    return View(model);
                }
            }
            return RedirectToAction("Index", "ForgotPassword");
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(ValidateResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.code == HttpContext.Session.GetString(model.email))
                {
                    var user = await _userManager.FindByNameAsync(model.email);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, model.newPassword);
                    if(result.Succeeded)
                    {
                        ViewBag.succeeded = "Your password is change please login again";
                        return View();
                    }
                    else
                    {
                        foreach(var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                            return View();
                        }
                    }
                }else
                {
                    ModelState.AddModelError(string.Empty, "Your code is invalid");
                    return View();
                }
            }
            return View();
        }
    }
}
