using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class EditArticleTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EditArticleTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
                var result = await articleTypeManager.GetArticleWithId(id);
                if(result != null)
                {
                    EditArticleType model = new EditArticleType();
                    model.id = result.ArticleTypeId;
                    model.icon = result.image;
                    model.name = result.Name;
                    return View(model);
                }
            }
            return RedirectToAction("Index", "ErrorSite");
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditArticleType model)
        {
            ArticleType articleType = new ArticleType();
            articleType.image = model.icon;
            articleType.Name = model.name;
            articleType.ArticleTypeId = model.id;
            ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
            bool result = await articleTypeManager.UpdateArticleType(articleType);
            if (result)
            {
                ViewBag.updateSucceeded = "This article is updated";
            } else
            {
                ModelState.AddModelError(string.Empty,"Some thing wrong, please try again");
            }
            return View();
        }
    }
}
