using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CDW2Project.Controllers
{
    public class WatchArticleController : Controller
    {
        public IActionResult Index(string id)
        {
            return View();
        }
    }
}
