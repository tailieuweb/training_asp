using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class EditPasswordUserController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserAccount> _signInManager;
        public EditPasswordUserController(UserManager<UserAccount> userManager,
            ApplicationDbContext context,
            IMapper mapper,
            SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (id != "")
            {
                var getUser = await _userManager.FindByIdAsync(id);
                var getCookieName = User.Identity.Name;
                if (getUser != null)
                {
                    var getCookieUser = await _userManager.FindByNameAsync(getCookieName);
                    if (getUser.Id == getCookieUser.Id)
                    {
                        bool hasPassword = await _userManager.HasPasswordAsync(getCookieUser);
                        ChangePasswordViewModel model = new ChangePasswordViewModel();
                        model.hasPassword = hasPassword;
                        model.id = id;
                        return View("Index", model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "ErrorSite");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "ErrorSite");
                }
            }
            return RedirectToAction("Index", "ErrorSite");
        }
        [HttpPost]
        public async Task<IActionResult> Index(ChangePasswordViewModel model)
         {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.id);
                if (model.currentPassword == "hidden" && model.hasPassword == false)
                {
                    var result = await _userManager.AddPasswordAsync(user, model.newPassword);
                    await _signInManager.RefreshSignInAsync(user);
                    if (result.Succeeded)
                    {
                        ViewBag.succeeded = "Change password is succeeded";
                        ModelState.Clear();
                        return View("Index", model);
                    }else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                            return View("Index", model);
                        }
                    }
                }
                else
                    {
                    var result = await _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);
                    await _signInManager.RefreshSignInAsync(user);
                    if (result.Succeeded)
                    {
                        ViewBag.succeeded = "Change password is succeeded";
                         ModelState.Clear();
                        return View("Index", model);
                    }else
                    {
                        foreach(var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                            return View("Index", model);
                        }
                    }
                }
            }
            return View("Index",model);
        }
    }
}
