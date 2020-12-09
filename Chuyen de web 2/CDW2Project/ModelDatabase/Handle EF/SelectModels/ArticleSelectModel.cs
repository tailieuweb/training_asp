using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDatabase.Handle_EF.SelectModels
{
    public class ArticleSelectModel
    {
        private string articleId;
        private string title;
        private string content;
        private int like;
        private DateTime date;
        private string avatar;
        private bool status;
        private string articleUserId;
        private string articleArticleTypeId;

        public string ArticleId { get => articleId; set => articleId = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public int Like { get => like; set => like = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public bool Status { get => status; set => status = value; }
        public string ArticleUserId { get => articleUserId; set => articleUserId = value; }
        public string ArticleArticleTypeId { get => articleArticleTypeId; set => articleArticleTypeId = value; }
        public ArticleSelectModel()
        {

        }

        public ArticleSelectModel(string articleId, string title, string content, int like, DateTime date, string avatar, bool status, string articleUserId, string articleArticleTypeId)
        {
            ArticleId = articleId;
            Title = title;
            Content = content;
            Like = like;
            Date = date;
            Avatar = avatar;
            Status = status;
            ArticleUserId = articleUserId;
            ArticleArticleTypeId = articleArticleTypeId;
        }
        public ArticleSelectModel(string articleId,string title,DateTime date,bool status,string articleUserId,string articleArticleTypeId,string content)
        {
            this.articleId = articleId;
            this.title = title;
            this.date = date;
            this.status = status;
            this.articleUserId = articleUserId;
            this.ArticleArticleTypeId = articleArticleTypeId;
            this.content = content;
        }
    }
}
