using Identity.DataLibrary.Core;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.IdentityContext.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IdentityContext _context;
        public RoleRepository(IdentityContext context) : base(context) 
        {
            _context = context;
        }
    }
}
