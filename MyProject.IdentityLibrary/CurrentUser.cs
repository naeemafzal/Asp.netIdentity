using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Identity.ModelsLibrary;
using Microsoft.AspNet.Identity;

namespace Identity.IdentityLibrary
{
    public class CurrentUser
    {
        public static AppUserInfo GetCurrentUserInfo()
        {
            if (HttpContext.Current != null && HttpContext.Current.User != null
                && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return GetCurrentUserInfo(HttpContext.Current.User);
            }

            return AppUserInfo.DefaultUser;
        }

        private static AppUserInfo GetCurrentUserInfo(IPrincipal user)
        {
            var claimsIdentity = (ClaimsIdentity)user.Identity;
            var id = int.Parse(claimsIdentity.GetUserId());
            var username = claimsIdentity.Name;
            var fullname = claimsIdentity.FindFirst(CustomClaims.Fullname).Value;
            var active = bool.Parse(claimsIdentity.FindFirst(CustomClaims.Active).Value);
            var profilePic = claimsIdentity.FindFirst(CustomClaims.ProfilePic).Value;

            return new AppUserInfo(id, username, fullname, active, profilePic);
        }
    }
}
