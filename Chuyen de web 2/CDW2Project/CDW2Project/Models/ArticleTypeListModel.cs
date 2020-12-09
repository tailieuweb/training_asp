using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.Models
{
    public class ArticleTypeListModel
    {
        public string ArticleType { set; get; }
        public List<ArticleType> ArticleTypeList { set; get; }
    }
}
