using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Identity.IdentityLibrary
{
    public class MyApplicationSignInManager : SignInManager<MyUser, string>
    {
        public MyApplicationSignInManager(MyApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(MyUser user)
        {
            return user.GenerateUserIdentityAsync((MyApplicationUserManager)UserManager);
        }

        public static MyApplicationSignInManager Create(IdentityFactoryOptions<MyApplicationSignInManager> options, IOwinContext context)
        {
            return new MyApplicationSignInManager(context.GetUserManager<MyApplicationUserManager>(), context.Authentication);
        }
    }
}
