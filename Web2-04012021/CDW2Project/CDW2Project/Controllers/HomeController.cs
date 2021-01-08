using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CDW2Project.Models;
using ModelDatabase;
using Microsoft.AspNetCore.Authorization;
using ModelDatabase.Handle_EF;
using CDW2Project.FetchModel;

namespace CDW2Project.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ArticleManager articleManager = new ArticleManager(_context);
            ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
            TypeAndArticleList typeAndArticleList = new TypeAndArticleList();
            var articleList = articleManager.GetLatestFourNewsArticles();
            var articleTypeList = articleTypeManager.GetArticleTypeList();
            if (articleList.Any())
            {
                typeAndArticleList.articles = articleList;
            }
            if (articleTypeList.Any())
            {
                typeAndArticleList.articleTypes = articleTypeList;
            }
            return View(typeAndArticleList);
        }
        public JsonResult getAllArticlesBySearchType([FromBody]PostSearchTypeArticles model)
        {
            ArticleManager articleManager = new ArticleManager(_context);
            var result = articleManager.GetArticlesListWithSearchType(model.articleType, model.searchedContent, model.take, model.skip);
            if (result.Any())
            {
                return Json(new { articleList = result });
            }
            return Json(new { articleList = ""});
        }
        [HttpPost]
        public JsonResult getAllUser([FromBody] PostAllUser model)
        {
            if (ModelState.IsValid)
            {
                UserAccountManager userAccountManager = new UserAccountManager(_context);
                var result = userAccountManager.GetUserSkipTake(model.take, model.skip);
                return Json(new { userList = result });
            }
            return Json(new { });
        }
    }
}
