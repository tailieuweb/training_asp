using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CDW2Project.FetchModel;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class PersonalPageController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _ev;
        public PersonalPageController(UserManager<UserAccount> userManager, 
            IMapper mapper, 
            ApplicationDbContext context,
            IWebHostEnvironment ev)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context= context;
            _ev = ev;
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
                    PersonalUserViewModel model = _mapper.Map<PersonalUserViewModel>(getUser);
                    ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
                    model.articleTypes = articleTypeManager.GetArticleTypeList();
                    if (getUser.Id == getCookieUser.Id)
                    {
                        return View("Index", model);    
                    }else
                    {
                        return View("OtherUser", model);
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
        public async Task<IActionResult>  UploadPersonalImage(PostPersonalImageModel model)
        {
            if (ModelState.IsValid)
            {
                string path = _ev.WebRootPath + $"\\User_Image\\{model.UserId}";
                var file = model.File;
                string fileName = file.FileName;
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.Image = file.FileName;
                var updatedData = await _userManager.UpdateAsync(user);
                string createImagePath = Path.Combine(path, fileName);
                if (updatedData.Succeeded)
                {
                    if (Directory.Exists(path))
                    {
                        DirectoryInfo dic = new DirectoryInfo(path);
                        foreach (FileInfo item in dic.GetFiles())
                        {
                            item.Delete();
                        }
                        var stream = new FileStream(createImagePath, FileMode.Create, FileAccess.Write);
                        await  model.File.CopyToAsync(stream);
                        stream.Flush();
                        stream.Close();
                    }
                    FileInfo isExitsFile = new FileInfo(createImagePath);
                    if (isExitsFile.Exists)
                    {
                        return Json(new { created = true});
                    }else
                    {
                        return BadRequest("Data is not update");
                    }
                    
                }

            }
            return BadRequest("Data passed into server is invalid");
        }
        [HttpPost]
        public async Task<ActionResult> GetUserArticles([FromBody] PostUserArticle model)
        {
            if (ModelState.IsValid)
            {
                ArticleManager articleManager = new ArticleManager(_context);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var articleList = articleManager.GetUserArticleTakeSkip(model.userId,  model.take, model.skip, model.searchedContent,model.status,model.ArticleArticleTypeId);
                if (articleList.Any())
                {
                    return Json(new { getData = true, dataList = articleList });
                }
                return new JsonResult(new { getData = true, dataList = articleList });
            }
            return new JsonResult(new { getData = false, dataList = "System made a error,please try again" });
        }
    }
}
