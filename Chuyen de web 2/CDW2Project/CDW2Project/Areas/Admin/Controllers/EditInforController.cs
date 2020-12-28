using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CDW2Project.Areas.Admin.Models;
using CDW2Project.FetchModel;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class EditInforController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _ev;
        public EditInforController(UserManager<UserAccount> userManager, 
            IMapper mapper, 
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment ev)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
            _ev = ev;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    EditInforAdminModel model = _mapper.Map<EditInforAdminModel>(user);
                    ArticleManager articleManager = new ArticleManager(_context);
                    model.ArticlesList = articleManager.ArticlesOfUser(id);
                    IList<string> rolesOfUser = await _userManager.GetRolesAsync(user);
                    model.validateRole = rolesOfUser.SingleOrDefault();
                    model.validateOldRole = rolesOfUser.SingleOrDefault();
                    model.roles =  _roleManager.Roles.ToList();
                    return View(model);
                }
            }
            return RedirectToAction("ErrorSite", "Index");
        }
        [HttpPost]
        public async Task<IActionResult> Index(string id, EditInforAdminModel model)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    ArticleManager articleManager = new ArticleManager(_context);
                    model.ArticlesList = articleManager.ArticlesOfUser(id);
                    model.roles = _roleManager.Roles.ToList();
                    if (ModelState.IsValid)
                    {
                        user.FullName = model.FullName;
                        user.Address = model.Address;
                        var updateUser = await _userManager.UpdateAsync(user);
                        if(updateUser.Succeeded)
                        {
                            user = await _userManager.FindByIdAsync(id);
                            ViewBag.updateUserSucceeded = "You have change user information is succeeded";
                        }else
                        {
                            foreach(var item in updateUser.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                        if(model.validateRole != model.validateOldRole)
                        {
                           var isRemove = await _userManager.RemoveFromRoleAsync(user, model.validateOldRole);
                            if(isRemove.Succeeded)
                            {
                              var isAddRole = await _userManager.AddToRoleAsync(user, model.validateRole);
                               if(isAddRole.Succeeded)
                                {
                                    ViewBag.addRoleSucceeded = "You have changed role is succeeded";
                                }else
                                {
                                    foreach (var item in isRemove.Errors)
                                    {
                                        ModelState.AddModelError(string.Empty, item.Description);
                                    }
                                }
                            }
                            else
                            {
                                foreach(var item in isRemove.Errors)
                                {
                                    ModelState.AddModelError(string.Empty, item.Description);
                                }
                            }
                        }
                        if (model.newPassword != null)
                        {
                           var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                           var resetPassword = await _userManager.ResetPasswordAsync(user, token, model.newPassword);
                            if(resetPassword.Succeeded)
                            {
                                ViewBag.changePasswordSucceeded = "You have changed password is succeeded";
                            }else
                            {
                                foreach(var item in resetPassword.Errors)
                                {
                                    ModelState.AddModelError(string.Empty, item.Description);
                                }
                            }
                        }
                    }
                    model.UserName = user.UserName;
                    model.Image = user.Image;
                    return View(model);
                }
            }
            return RedirectToAction("ErrorSite", "Index");
        }
        [HttpPost]
        public async Task<IActionResult> UploadPersonalImage(PostPersonalImageModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user != null)
                {
                    string path = _ev.WebRootPath + $"\\User_Image\\{model.UserId}";
                    var file = model.File;
                    string fileName = file.FileName;
                    user.Image = fileName;
                    var result = await _userManager.UpdateAsync(user);
                    string createImagePath = Path.Combine(path, fileName);
                    if (result.Succeeded)
                    {
                        if (Directory.Exists(path))
                        {
                            DirectoryInfo dic = new DirectoryInfo(path);
                            foreach (FileInfo item in dic.GetFiles())
                            {
                                item.Delete();
                            }
                            var stream = new FileStream(createImagePath, FileMode.Create, FileAccess.Write);
                            await model.File.CopyToAsync(stream);
                            stream.Flush();
                            stream.Close();
                        }
                        FileInfo isExitsFile = new FileInfo(createImagePath);
                        if (isExitsFile.Exists)
                        {
                            return Json(new { update = true, message = "You have changed your image is succeeded" });
                        }
                    }
                }
                else
                {
                    return Json(new { update = false, message = "Id user is invalid,please try again" });
                }
            }
            return Json(new { update = false,message = "Something is wrong,please try again"});
        }
        public async Task<IActionResult> DeleteArticle(string id)
        {
            ArticleManager articleManager = new ArticleManager(_context);
            bool result = await articleManager.DeleteArticle(id);
            if(result)
            {
                return Json(new { delete = result,message = "You have deleted this article"});
            }
            return Json(new { delete = result,message = "Something is wrong,please try again" });
        }
    }
}
