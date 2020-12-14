using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HeaderViewComponent(UserManager<UserAccount> userManager,
             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            UserInterfaceViewModel model = new UserInterfaceViewModel();
            if (result != null)
            {
                model.id = result.Id;
                model.fullName = result.FullName;
                model.roles = await _userManager.GetRolesAsync(result);
                if (result.Image != null)
                {
                    model.avatar = "/User_Image/"+$"{result.Id}/"+$"{result.Image}";
                }
                else
                {
                    model.avatar = "/img/emty_avatar.jpg";
                }

            }
            return View("Default",model);
        }
    }
}
