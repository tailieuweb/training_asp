using ModelDatabase.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelDatabase.Handle_EF
{
    public class CommentManager
    {
        private ApplicationDbContext _context;
        public CommentManager(ApplicationDbContext context)
        {
            _context = context;
        } 
        public async Task<bool> InsertComment(Comment comment)
        {
            bool result = true;
            try
            {
                await _context.Comment.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> DeleteComment(string id)
        {
            bool result = true;
            try
            {
                _context.Comment.Remove(_context.Comment.Find(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                 result = false;
            }
            return result;
        }
        public async Task<bool> UpdateComment(Comment comment)
        {
            bool result = true;
            try
            {
                var com = _context.Comment.Find(comment.CommentId);
                com.Content = comment.Content;
                _context.Update(com);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
