using System;
using Identity.DataLibrary.IdentityContext.Repositories;

namespace Identity.DataLibrary.IdentityContext
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
		IRoleRepository Roles { get; }
        int Complete();
    }
}
