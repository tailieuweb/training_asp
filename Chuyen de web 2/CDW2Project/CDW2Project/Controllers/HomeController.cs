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
            //var result = articleManager.GetLatestFiveNewsArticles();
            return View();
        }
    }
}
