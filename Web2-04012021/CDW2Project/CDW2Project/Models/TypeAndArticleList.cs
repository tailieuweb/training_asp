using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class TypeAndArticleList
    {
        public List<Article> articles { set; get; }
        public List<ArticleType> articleTypes { set; get; }
    }
}
