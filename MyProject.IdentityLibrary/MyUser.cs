using System.Security.Claims;
using System.Threading.Tasks;
using Identity.ModelsLibrary;
using Microsoft.AspNet.Identity;

namespace Identity.IdentityLibrary
{
    public class MyUser : User, IUser<string>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(MyApplicationUserManager manager)
        {
            //AuthenticationType must be the same as the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //Add custom user claims here
            userIdentity.AddClaim(new Claim(CustomClaims.Firstname, Firstname, ClaimValueTypes.String));
            userIdentity.AddClaim(new Claim(CustomClaims.Lastname, Lastname, ClaimValueTypes.String));
            userIdentity.AddClaim(new Claim(CustomClaims.Fullname, Fullname, ClaimValueTypes.String));
            userIdentity.AddClaim(new Claim(CustomClaims.Active, Active.ToString(), ClaimValueTypes.Boolean));
            userIdentity.AddClaim(new Claim(CustomClaims.ProfilePic, ProfilePic, ClaimValueTypes.String));

            foreach (var role in Roles)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String));
            }

            return userIdentity;
        }
    }
}
