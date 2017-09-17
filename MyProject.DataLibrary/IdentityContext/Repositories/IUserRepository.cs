using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
     public interface IUserRepository : IRepository<User>
    {
         User GetUser(int userId);
         User GetUser(string username);
    }
}
