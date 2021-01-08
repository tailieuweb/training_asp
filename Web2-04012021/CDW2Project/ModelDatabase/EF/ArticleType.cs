using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelDatabase.EF
{
    public class ArticleType
    {
        [Key]
        public string ArticleTypeId { set; get; }
        public string Name { set; get; }
        public string image { set; get; }
        public List<Article> ArticlesList { set; get; }
    }
}
