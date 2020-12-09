using Microsoft.AspNetCore.Identity;
using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModel.CustomIdentityUser
{
    public class UserAccount:IdentityUser
    {
        public string FullName { set; get; }
        public string Image { set; get; }
        public string Address { set; get; }
        public List<Article> ArticlesList { set; get; }
        public List<Comment> commentsList { set; get; }
    }
}
