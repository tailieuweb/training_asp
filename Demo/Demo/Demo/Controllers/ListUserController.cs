using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Demo.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ListUserController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ListUserController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            List<CustomUser> getUserList =  _userManager.Users.ToList();
            List<ListUserViewModel> userViewList = new List<ListUserViewModel>();
            foreach(CustomUser item in getUserList)
            {
                ListUserViewModel model = new ListUserViewModel();
                model.id = item.Id;
                model.email = item.Email;
                model.fullName = item.FullName;
                var roles = await _userManager.GetRolesAsync(item);
                model.roles = roles.ToList();
                userViewList.Add(model);
            }
            return View(userViewList);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string idUser)
        {
            var getUser = await _userManager.FindByIdAsync(idUser);
            EditUserViewModel model = new EditUserViewModel();
            if (getUser != null)
            {
                model.id = idUser;
                model.email = getUser.Email;
                model.fullName = getUser.FullName;
                var arr = await  _userManager.GetRolesAsync(getUser);
                model.oldRole = arr.ToList().SingleOrDefault();
                model.newRole = arr.ToList().SingleOrDefault();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var getUser = await _userManager.FindByIdAsync(model.id);
            getUser.FullName = model.fullName;
            getUser.UserName = model.email;
            getUser.Email = model.email;
            await _userManager.RemoveFromRoleAsync(getUser, model.oldRole);
            await _userManager.AddToRoleAsync(getUser, model.newRole);
            return RedirectToAction("Index","ListUser");
        }
        public async Task<IActionResult> DeleteUser(string idUser)
        {
            var getUser = await _userManager.FindByIdAsync(idUser);
            var result = await _userManager.DeleteAsync(getUser);
            if (result.Succeeded && User.Identity.Name != getUser.UserName)
            {
                return RedirectToAction("Index", "ListUser");
            }
            return RedirectToAction("Index", "ListUser");
        }
    }
}
