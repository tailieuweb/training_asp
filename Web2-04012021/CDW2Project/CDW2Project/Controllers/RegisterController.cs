using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDW2Project.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IWebHostEnvironment _ev;
        //Custructor of Register Controller
        public RegisterController(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAccount> signInManager,
            IWebHostEnvironment ev)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _ev = ev;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.externalRegister = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            model.externalRegister = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                UserAccount user = new UserAccount()
                {
                    Email = model.email,
                    UserName = model.email,
                    FullName = model.userName
                };
                var result = await _userManager.CreateAsync(user, model.password);
                //Khi đăng nhập thành công sẽ thêm role,xác nhận token email...
                if (result.Succeeded)
                {
                    string userfolderPath = _ev.WebRootPath + @"\User_Image\" + user.Id;
                    if (!Directory.Exists(userfolderPath))
                    {
                        Directory.CreateDirectory(userfolderPath);
                        Directory.SetCreationTime(userfolderPath, DateTime.Now);
                    }
                    //Add Role for User have just created 
                    await _userManager.AddToRoleAsync(user, "User");
                    //Generate Email confirmation token for user
                    var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("Index", "ConfirmEmail", new { userId = user.Id, token = token.Result }, Request.Scheme);
                    //Add token path into EmailConfirmation Service to send message throught email
                    bool getEmailConfirmationResult = await EmailConfirmation.SendEmailToUser(user.Email, confirmationLink);
                    if (getEmailConfirmationResult)
                    {
                        var successedThings = new Dictionary<string, string>();
                        successedThings.Add("Generate", "Khởi tạo thành công");
                        successedThings.Add("SendConfirmation", "Chúng tôi đã gửi xác nhận qua email của bạn");
                        ViewBag.successed = successedThings;
                        ModelState.Clear();
                    }
                    else
                    {
                        ModelState.Clear();
                        await _userManager.DeleteAsync(user);
                        Directory.Delete(userfolderPath);
                        ModelState.AddModelError(string.Empty, "Server have error,please try again!");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult ExternalRegister(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Register");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var claimsEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
            var fullName = info.Principal.FindFirstValue(ClaimTypes.Name);
            if (claimsEmail != null && fullName != null)
            {
                UserAccount user = new UserAccount();
                user.Email = claimsEmail;
                user.UserName = claimsEmail;
                user.FullName = fullName;
                var createUser = await _userManager.CreateAsync(user);
                if (createUser.Succeeded)
                {
                    string userfolderPath = _ev.WebRootPath + @"\User_Image\" + user.Id;
                    if (!Directory.Exists(userfolderPath))
                    {
                        Directory.CreateDirectory(userfolderPath);
                        Directory.SetCreationTime(userfolderPath, DateTime.Now);
                    }
                    // find and confirm User when login with google account
                    var cofimEmail = await _userManager.FindByNameAsync(user.Email);
                    cofimEmail.EmailConfirmed = true;
                    await _userManager.AddLoginAsync(user, info);
                    await _userManager.AddToRoleAsync(user, "User");
                    var loginLink = Url.Action("Index", "Loginin");
                    return LocalRedirect(loginLink);
                }
                else
                {
                    RegisterViewModel model = new RegisterViewModel();
                    model.externalRegister = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                    foreach (var item in createUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                    return View("Index", model);
                }
            }
            var errorLink = Url.Action("Index", "ErrorSite");
            return LocalRedirect(errorLink);
        }
    }
}
