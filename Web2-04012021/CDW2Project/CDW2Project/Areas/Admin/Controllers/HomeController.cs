using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        public HomeController(UserManager<UserAccount> userManager,
         SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public IActionResult Index(int? page,string search)
        {
            var pageNumber = page ?? 1;
            ViewBag.search = search;
            IPagedList<UserAccount> users = _userManager.Users.Where(x => search != null ? x.FullName.Contains(search) : x.FullName.Contains("")).ToPagedList(pageNumber,3);
            return View(users);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                if (user.UserName != User.Identity.Name)
                {
                    await _userManager.DeleteAsync(user);
                    return Json(new { delete = true, message = "Delete was succeeded" });
                }else
                {
                    return Json(new { delete = false,message = "Can't delete when you are using your account" });
                }
            }
            return Json(new { delete = false,message ="Some thing wrong, please try again!" });
        }
        public async Task<IActionResult> LogoutUser()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Loginin");
        }
    }
}
