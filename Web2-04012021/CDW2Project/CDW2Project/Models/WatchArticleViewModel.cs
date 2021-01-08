using Microsoft.AspNetCore.Identity;
using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class WatchArticleViewModel
    {
        public Article article { set; get; }
        public string currentUserId { set; get; }
        public IList<string> roles { set; get; }
    }
}
