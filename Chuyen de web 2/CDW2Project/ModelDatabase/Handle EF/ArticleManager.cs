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
        public async Task<Article> GetLatestFiveNewsArticles()
        {
            var result = _context.Article.ToList();
            return null;
        }
    }
}
