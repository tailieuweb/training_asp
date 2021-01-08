using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.FetchModel
{
    public class PostUserArticle
    {
        public bool status { set; get; }
        public string ArticleArticleTypeId { set; get; }
        public int take { set; get; }
        public int skip { set; get; }
        public string searchedContent { set; get; }
        public string userId { set; get; }
    }
}
