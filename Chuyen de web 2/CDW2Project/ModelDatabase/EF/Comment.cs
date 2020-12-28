using DatabaseModel.CustomIdentityUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelDatabase.EF
{
    public class Comment
    {
        [Key]
        public string CommentId { set; get; }
        public virtual UserAccount UserAccount {set;get;}
        public string CommentUserAccountId { set; get; }
        public virtual Article Article { set; get; }
        public string CommentArticleId { set; get; }
        public DateTime Date { set; get; }
        public string Content { set; get; }
    }
}
