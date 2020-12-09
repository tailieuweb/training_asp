using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.FetchModel;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class StoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserAccount> _userManager;
        private readonly IWebHostEnvironment _ev;
        public StoriesController(ApplicationDbContext context,
            UserManager<UserAccount> userManager,
            IWebHostEnvironment ev)
        {
            _context = context;
            _userManager = userManager;
            _ev = ev;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetArticleHaveType([FromBody] PostStoriesModel model)
        {
            if (ModelState.IsValid)
            {
                ArticleManager articleManager = new ArticleManager(_context);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var articleList = articleManager.GetArticleListHaveStatus(user.Id, model.articleType, model.take, model.skip, model.searchedContent);
                if (articleList.Any())
                {
                    return Json(new { getData = true, dataList = articleList });
                }
                return new JsonResult(new { getData = true, dataList = articleList });
            }
            return new JsonResult(new { getData = false, dataList = "System made a error,please try again" });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeArticleStatus([FromBody] PostChangeStatus model)
        {
            if (ModelState.IsValid)
            {
                Article article = new Article();
                article.AriticleId = model.articleId;
                article.Status = !model.status;
                ArticleManager articleManager = new ArticleManager(_context);
                bool result = await articleManager.ChangeArticleStatus(article);
                if (result)
                {
                    return Json(new { changed = true });
                }
            }
            return Json(new { changed = false });
        }
        public async Task<ActionResult> DeleteArticle([FromBody] GetArticleModel model)
        {
            if (ModelState.IsValid)
            {
                ArticleManager articleManager = new ArticleManager(_context);
                var result = await articleManager.DeleteArticle(model.ArticleId);
                string path = _ev.WebRootPath + $"\\Article_Image\\{model.ArticleId}";
                bool deleteDic = false;
                if (Directory.Exists(path))
                {
                    DirectoryInfo dic = new DirectoryInfo(path);
                    foreach (FileInfo file in dic.GetFiles())
                    {
                        file.Delete();
                    }
                    if (!dic.GetFiles().Any())
                    {
                        dic.Delete();
                        deleteDic = true;
                    }
                }
                if (result && deleteDic)
                {
                    return Json(new { deleted = true });
                }
            }
            return Json(new { deleted = false });
        }
    }
}
