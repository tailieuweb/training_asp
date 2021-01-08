using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.Handle_EF;
using X.PagedList;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ArticleTypesController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly ApplicationDbContext _context;
        public ArticleTypesController(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAccount> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index(int? page, string search)
        {
            int pageNumber = page ?? 1;
            string searchValue = search ?? "";
            ViewBag.search = search;
            ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
            var result = articleTypeManager.GetArticleTypeListSearch(searchValue).ToPagedList(pageNumber, 3);
            if (result.Any())
            {
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteArticleType(string id)
        {
            ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
            bool result =  await articleTypeManager.DeleteArticleType(id);
            if (result)
            {
                return Json(new { delete = true, message = "This article type is deleted" });
            }
            return Json(new { delete = false, message = "Something wrong,please try again!" });
        }
    }
}
