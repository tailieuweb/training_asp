using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.EF;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterController(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //Khi người dùng trỏ đến địa chỉ này, mặc định sẽ vào Index Action Method
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Khi người dùng post request lên
        //Model RegisterViewModel sễ dc route combieding xử lý và trả về dữ liệu
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Khởi tạo thông tin người với mục đích là lưu vào database
                CustomUser user = new CustomUser
                {
                    UserName = model.email,
                    Email = model.email,
                    FullName = model.fullName
                };
                //Khi sử dung _userManager.CreateAsync() --> Lưu vào database
                var result = await _userManager.CreateAsync(user, model.password);
                //Nếu lưu thành công thì succeeded == true or false
                if (result.Succeeded)
                {
                    //thêm vai trò cho user khi đăng ký
                    await _userManager.AddToRoleAsync(user, "User");
                    //Tạo một token để người dùng xác nhận
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("Index", "ConfirmEmail", new { userId = user.Id, token }, Request.Scheme);
                    //Bỏ đường dẫn vào trong EmailConfirmation để gửi token đến email của người tạo
                    bool getEmailConfirmationResult = await EmailConfirmation.SendEmailToUser(user.Email, confirmationLink);
                    if (getEmailConfirmationResult)
                    {
                        return RedirectToAction("SucceededRegister", "Register");
                    }
                    else
                    {
                        return RedirectToAction("NotSucceededRegister", "Register");
                    }
                    //Chuyển hướng trang sang Login
                }
                else
                {
                    // In ra các lỗi không thể lưu vào database dc
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult SucceededRegister()
        {
            return View();
        }

        public IActionResult NotSucceededRegister()
        {
            return View();
        }
    }
}