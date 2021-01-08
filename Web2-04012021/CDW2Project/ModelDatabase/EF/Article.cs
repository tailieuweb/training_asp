using DatabaseModel.CustomIdentityUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelDatabase.EF
{
    public class Article
    {
        [Key]
        public string AriticleId { set; get; }
        public string Title { set; get; }
        public string Content { set; get; }
        public int? Like { set; get; }
        public DateTime Date { set; get; }
        public virtual UserAccount UserAccount{set;get;}
        public string ArticleUserId { set; get; }
        public string Avatar { set; get; }
        public bool Status { set; get; }
        public virtual ArticleType ArticleType { set; get; }
        public string ArticleArticleTypeId { set; get; }
        public List<Comment> CommentsList { set; get; }
    }
}
