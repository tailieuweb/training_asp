using Microsoft.EntityFrameworkCore;
using ModelDatabase.EF;
using ModelDatabase.Handle_EF.SelectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDatabase.Handle_EF
{
    public class ArticleManager
    {
        private ApplicationDbContext _context;
        public ArticleManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateArticleInformation(Article ar)
        {
            bool result = true;
            try
            {
                var addResult = await _context.Article.AddAsync(ar);
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> UpdateDate_Type_Content_Avatar_Title(Article ar)
        {
            bool result = true;
            try
            {
                _context.Article.Attach(ar);
                _context.Entry(ar).Property(e => e.ArticleArticleTypeId).IsModified = true;
                _context.Entry(ar).Property(e => e.Content).IsModified = true;
                _context.Entry(ar).Property(e => e.Date).IsModified = true;
                _context.Entry(ar).Property(e => e.Avatar).IsModified = true;
                _context.Entry(ar).Property(e => e.Title).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<Article> GetArticleInformation(string id)
        {
            var result = await _context.Article.FindAsync(id);
            return result;
        }
        public List<ArticleSelectModel> GetArticleListHaveStatus(string userId, bool status,int take,int skip,string searchedContent)
        {
            var result = _context.Article.Where(x => x.Status == status && x.ArticleUserId == userId && x.Title.Contains(searchedContent)).Skip(skip).Take(take)
                .Select((value) => new ArticleSelectModel(
                    value.AriticleId,
                    value.Title,
                    value.Date,
                    value.Status,
                    value.AriticleId,
                    value.ArticleArticleTypeId,
                    value.Content)).ToList();
            return result;
        }
        public async Task<bool> ChangeArticleStatus(Article article)
        {
            bool result = true;
            try
            {
                _context.Article.Attach(article);
                _context.Entry(article).Property(e => e.Status).IsModified = true;
                await _context.SaveChangesAsync();
            }catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> DeleteArticle(string id)
        {
            bool result = true;
            try
            {
                _context.Article.Remove(_context.Article.Find(id));
               await _context.SaveChangesAsync();
            }catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public List<Article> GetLatestFourNewsArticles()
        {
            var result = _context.Article.OrderByDescending(x => x.Date).Include(type => type.ArticleType).Where(x => x.Status == true).Take(4).ToList();
            return result;
        }
        public List<Article> GetArticlesListWithSearchType(string articleType,string searchedContent,int take,int skip)
        {
            if (articleType == "other")
            {
               return _context.Article.Where(x => x.Title.Contains(searchedContent) && x.Status == true)
                    .Include(type => type.ArticleType)
                    .OrderByDescending(x => x.Date)
                    .Skip(skip).Take(take)
                    .ToList();
            }
            var result = _context.Article.Where(x => x.Title.Contains(searchedContent) && x.ArticleArticleTypeId == articleType && x.Status == true)
                .Include(type => type.ArticleType)
                .OrderByDescending(x => x.Date)
                .Skip(skip)
                .Take(take).ToList();
            return result;
        }
        public List<Article> GetUserArticleTakeSkip(string userId,int take,int skip,string searchedContent,bool status,string ArticleArticleTypeId)
        {
            if(ArticleArticleTypeId == "other")
            {
                var other = _context.Article.Where(a => a.ArticleUserId == userId && a.Title.Contains(searchedContent) && a.Status == status)
                 .OrderByDescending(or => or.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
                return other;
            }
            var result = _context.Article.Where(a => a.ArticleUserId == userId && a.Title.Contains(searchedContent) && a.Status == status && a.ArticleArticleTypeId == ArticleArticleTypeId)
            .Skip(skip)
            .Take(take)
            .ToList();
            return result;
        }
        public async Task<Article> GetArticleWithComment(string id)
        {
            var result = await _context.Article
                .Include(comment => comment.CommentsList.OrderByDescending(x => x.Date))
                    .ThenInclude(comment => comment.UserAccount)
                .Include(user => user.UserAccount)
                .Include(type => type.ArticleType)
                .Where(ar => ar.AriticleId == id)
                .FirstOrDefaultAsync();
            return result;
        }
        public async Task<bool> UpdateLikeArticle(Article article)
        {
            bool result = true;
            try
            {
                _context.Article.Attach(article);
                _context.Entry(article).Property(x => x.Like).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<int?> GetLikeArticle(string id)
        {
           var getArticle = await _context.Article.FindAsync(id);
           if(getArticle != null)
            {
                var result = getArticle.Like;
                return result;
            }
            return null;
        }
        public List<Article> ArticlesOfUser(string id)
        {
            List<Article> result =  _context.Article.Where(x => x.ArticleUserId == id).OrderByDescending(date => date.Date).Include(type => type.ArticleType).ToList();
            return result;
        }
    }
}
