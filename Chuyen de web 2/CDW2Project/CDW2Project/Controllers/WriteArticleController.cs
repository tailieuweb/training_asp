using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.FetchModel;
using CDW2Project.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class WriteArticleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserAccount> _userManager;
        private readonly IWebHostEnvironment _ev;
        public WriteArticleController(ApplicationDbContext context, UserManager<UserAccount> userManager,
            IWebHostEnvironment ev)
        {
            _context = context;
            _userManager = userManager;
            _ev = ev;
        }
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "ErrorSite");
            }
            ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
            ArticleTypeListModel model = new ArticleTypeListModel();
            model.ArticleType = articleTypeManager.GetFirstTypeId();
            model.ArticleTypeList = articleTypeManager.GetArticleTypeList();
            return View(model);
        }
        public async Task<IActionResult> SaveEditorImage(IFormFile upload, string id)
        {
            string fileName = DateTime.Now.ToString("yyyyyMMddHHmmss") + upload.FileName;
            string path = _ev.WebRootPath + $"\\Article_Image\\{id}";
            var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.Write);
            await upload.CopyToAsync(stream);
            stream.Flush();
            stream.Close();
            return new JsonResult(new
            {
                uploaded = true,
                url = "/Article_Image/" + id + "/" + fileName
            });
        }
        public async Task<IActionResult> Create()
        {
            //Create Id for Article 
            MD5Service md5 = new MD5Service();
            string articleId = md5.GetHashId();
            //Get Id User
            var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
            //Create Artile information emty
            Article article = new Article();
            article.AriticleId = articleId;
            article.Date = DateTime.Now;
            if (getUser != null)
            {
                article.ArticleUserId = getUser.Id.ToString();
                //article.ArticleUserId = getUser.Id;
                ArticleManager articleManager = new ArticleManager(_context);
                bool getCreateResult = await articleManager.CreateArticleInformation(article);
                if (getCreateResult == true)
                {
                    string pathDic = _ev.WebRootPath + @"\Article_Image\" + articleId;
                    if (!Directory.Exists(pathDic))
                    {
                        Directory.CreateDirectory(pathDic);
                        Directory.SetCreationTime(pathDic, DateTime.Now);
                    }
                    return RedirectToAction("Index", "WriteArticle", new { id = articleId });
                }
            }
            return RedirectToAction("Index", "ErrorSite");
        }
        [HttpPut]
        public async Task<JsonResult> LoadArticleData([FromBody] PutArticleModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.articleId))
                {
                    Article article = new Article();
                    article.AriticleId = model.articleId;
                    if (!string.IsNullOrEmpty(model.articleTypeId))
                    {
                        article.ArticleArticleTypeId = model.articleTypeId;
                    }
                    else
                    {
                        article.ArticleArticleTypeId = null;
                    }
                    article.Content = model.contentArticle;
                    article.Title = model.title;
                    article.Date = DateTime.Now;
                    string path = _ev.WebRootPath + $"\\Article_Image\\{model.articleId}";
                    if (model.imgList.Count > 0)
                    {
                        DirectoryInfo fileList = new DirectoryInfo(path);
                        foreach (FileInfo item in fileList.GetFiles())
                        {
                            if (!model.imgList.Contains(Path.GetFileName(item.FullName)))
                            {
                                item.Delete();
                            }
                        }
                        article.Avatar = Path.GetFileName(fileList.GetFiles().First().ToString());
                    }
                    else
                    {
                        DirectoryInfo fileList = new DirectoryInfo(path);
                        foreach (FileInfo item in fileList.GetFiles())
                        {
                            item.Delete();
                        }
                    }
                    ArticleManager articleManager = new ArticleManager(_context);
                    bool result = await articleManager.UpdateDate_Type_Content_Avatar_Title(article);
                    if (result == true)
                    {
                        return new JsonResult(new { updated = true, articleContent = "Update was successful" });
                    }
                }
                return new JsonResult(new { updated = false, articleContent = "Sorry!. Your article is not save" });
            }
            return new JsonResult(new { updated = false, articleContent = "Sorry!. Your article is not save" });
        }
        [HttpPost]
        public async Task<JsonResult> GetArticleData([FromBody] GetArticleModel model)
        {
            if (ModelState.IsValid)
            {
                ArticleManager articleManager = new ArticleManager(_context);
                Article article = await articleManager.GetArticleInformation(model.ArticleId);
                if (article != null)
                {
                    return new JsonResult(new { postData = true, articleContent = article.Content, articleTypeId = article.ArticleArticleTypeId });
                }

            }
            return new JsonResult(new { postData = false, articleContent = "Sorry!. Some thing is wrong" });
        }

    }
}
