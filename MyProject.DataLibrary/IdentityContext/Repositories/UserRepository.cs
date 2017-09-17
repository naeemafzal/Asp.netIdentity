using System.Data.Entity;
using System.Linq;
using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IdentityContext _context;
        public UserRepository(IdentityContext context) : base(context)
        {
            _context = context;
        }

        public User GetUser(int userId)
        {
            return _context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string username)
        {
            return _context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.Username == username);
        }
    }
}
