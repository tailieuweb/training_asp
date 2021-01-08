using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        public ForgotPasswordController(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.email);
                if(user != null)
                {
                    Guid guid = Guid.NewGuid();
                    var getCode = guid.ToString();
                    bool result = await EmailConfirmation.SendEmailToUser(model.email, getCode);
                    if (result)
                    {
                        HttpContext.Session.SetString(model.email, getCode);
                        string url = Url.Action("Index", "ValidateAndResetPassword",new {email = model.email });
                        return LocalRedirect(url);
                    }
                    return RedirectToAction("Index", "ErrorSite");
                }else
                {
                    ModelState.AddModelError(string.Empty, "Your email is't exist, please try again!");
                }
            }
            return View(model);
        }
    }
}
