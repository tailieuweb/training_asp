using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDatabase.Handle_EF
{
    public class ArticleTypeManager
    {
        private ApplicationDbContext _context;
        public ArticleTypeManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateArticleType(ArticleType articleType)
        {
            bool result = true;
            try
            {
                _context.ArticleType.Add(articleType);
               var a =  await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public List<ArticleType> GetArticleTypeList()
        {
            List<ArticleType> result =  _context.ArticleType.ToList();
            return result;
        }
        public string GetFirstTypeId()
        {
            ArticleType result = _context.ArticleType.First();
            return result.ArticleTypeId;
        }
        public List<ArticleType> GetArticleTypeListSearch(string search)
        {
            List<ArticleType> result = _context.ArticleType.Where(x => x.Name.Contains(search)).ToList();
            return result;
        }
        public async Task<bool> DeleteArticleType(string id)
        {
            var result = true;
            try
            {
                _context.ArticleType.Remove(_context.ArticleType.Find(id));
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<ArticleType> GetArticleWithId(string id)
        {
            try
            {
                var result = await _context.ArticleType.FindAsync(id);
                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public async Task<bool> UpdateArticleType(ArticleType type)
        {
            bool result = true;
            try
            {
                _context.ArticleType.Attach(type);
                _context.Entry(type).Property(e => e.image).IsModified = true;
                _context.Entry(type).Property(e => e.Name).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                 result = false;
            }
            return result;
        }
    }
}
