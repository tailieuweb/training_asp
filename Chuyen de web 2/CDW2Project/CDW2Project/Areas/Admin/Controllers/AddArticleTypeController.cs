using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDW2Project.Areas.Admin.Models;
using CDW2Project.Services;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF;

namespace CDW2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AddArticleTypeController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly ApplicationDbContext _context;
        public AddArticleTypeController(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAccount> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AddArticleTypeViewModel model)
        {
            if(ModelState.IsValid)
            {
                ArticleType type = new ArticleType();
                MD5Service key = new MD5Service();
                type.ArticleTypeId = key.GetHashId();
                type.image = model.icon;
                type.Name = model.name;
                ArticleTypeManager articleTypeManager = new ArticleTypeManager(_context);
                bool result = await articleTypeManager.CreateArticleType(type);
                if (result)
                {
                    ModelState.Clear();
                    ViewBag.createSucceeded = "This type is created";
                }else
                {
                    ModelState.AddModelError(string.Empty, "Somethings wrong, please try again");
                }
            }
            return View(model);
        }
    }
}
