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
                await _context.SaveChangesAsync();
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
    }
}
