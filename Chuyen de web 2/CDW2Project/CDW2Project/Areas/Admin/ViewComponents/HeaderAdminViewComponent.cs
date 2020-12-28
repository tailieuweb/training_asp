using AutoMapper;
using CDW2Project.Areas.Admin.Models;
using DatabaseModel.CustomIdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Areas.Admin.ViewComponents
{
    public class HeaderAdminViewComponent : ViewComponent
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HeaderAdminViewComponent(UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            HeaderAdminViewModel model =  _mapper.Map<HeaderAdminViewModel>(user);
            return View("Default", model);
        }
    }
}
