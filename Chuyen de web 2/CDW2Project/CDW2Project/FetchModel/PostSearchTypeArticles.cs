using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.FetchModel
{
    public class PostSearchTypeArticles
    {
        public string articleType { set; get; }
        public string searchedContent { set; get; }
        public int take { set; get; }
        public int skip { set; get; }
    }
}
