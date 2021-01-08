using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.CustomController
{
    public class LoginManagerController:Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home/Index");
            }
            base.OnActionExecuting(context);
        }
    }
}
