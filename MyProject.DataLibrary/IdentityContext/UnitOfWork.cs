using Identity.DataLibrary.IdentityContext.Repositories;

namespace Identity.DataLibrary.IdentityContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityContext _context;
        public UnitOfWork(IdentityContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
        }

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
