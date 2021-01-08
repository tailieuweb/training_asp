using DatabaseModel.CustomIdentityUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDatabase.Handle_EF
{
    public class UserAccountManager
    {
        private ApplicationDbContext _context;
        public UserAccountManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<UserAccount>GetUserSkipTake(int take,int skip)
        {
            var result = _context.UserAccount.Skip(skip).Take(take).ToList();
            return result;
        }
    }
}
