using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.FetchModel
{
    public class PutArticleModel
    {
        public string contentArticle { set; get; }
        public string articleId { set; get; }
        public List<string> imgList { set; get; }
        public string articleTypeId { set; get; }
        public string title { set; get; }
    }
}
