using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AddUserController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IWebHostEnvironment _ev;
        public AddUserController(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAccount> signInManager,
            IWebHostEnvironment ev)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _ev = ev;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(RegisterViewModel model)
        {
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
    }
}
