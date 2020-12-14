using AutoMapper;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelDatabase;
using System.Threading.Tasks;

namespace CDW2Project.Controllers
{
    public class EditInfoUserController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<UserAccount> _signInManager;
        public EditInfoUserController(UserManager<UserAccount> userManager,
            ApplicationDbContext context,
            IMapper mapper,
            SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
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
                    if (getUser.Id == getCookieUser.Id)
                    {
                        EditInfoUserViewModel model = new EditInfoUserViewModel();
                        model.fullName = getCookieUser.FullName;
                        model.address = getCookieUser.Address;
                        model.userId = id;
                        return View("Index", model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "ErrorSite");
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
        public async Task<IActionResult> Index(EditInfoUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                user.FullName = model.fullName;
                user.Address = model.address;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.succeeded = "Change information is succeeded";
                    ModelState.Clear();
                    return View("Index", model);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        return View("Index", model);
                    }
                }
            }
            return RedirectToAction("Index", "ErrorSite");
        }
    }
}
