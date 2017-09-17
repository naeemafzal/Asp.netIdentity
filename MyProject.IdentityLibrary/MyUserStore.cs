using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.ApiLibrary;
using Identity.ModelsLibrary;
using Microsoft.AspNet.Identity;

namespace Identity.IdentityLibrary
{
    public class MyUserStore : IUserStore<MyUser, string>, IUserLoginStore<MyUser, string>,
        IUserRoleStore<MyUser, string>, IUserPasswordStore<MyUser, string>,
        IUserSecurityStampStore<MyUser, string>, IUserEmailStore<MyUser, string>,
        IUserLockoutStore<MyUser, string>, IUserTwoFactorStore<MyUser, string>,
        IClaimsIdentityFactory<MyUser, string>, IUserPhoneNumberStore<MyUser, string>
    {
        private readonly AuthApi _userService;

        public MyUserStore(AppUserInfo appUserInfo)
        {
            _userService = new AuthApi(appUserInfo);
        }

        #region IUserStore
        public Task CreateAsync(MyUser user)
        {
            var userEntity = new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Phone = user.Phone,
                UserName = user.UserName,
                Password = user.Password,
                Active = user.Active,
                SecurityStamp = user.SecurityStamp,
                EmailVerified = false,
                PhoneVerified = false,
                CreatedOn = DateTime.Now,
                Deleted = false
            };

            _userService.CreateUser(userEntity);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(MyUser user)
        {
            //User should not delete itself
            return Task.FromResult(0);
        }

        public Task<MyUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Task.FromResult(default(MyUser));
            }

            var id = int.Parse(userId);
            var userRequest = _userService.GetUser(id);
            return Task.FromResult(userRequest != null ? MappUser(userRequest) : default(MyUser));
        }

        public Task<MyUser> FindByNameAsync(string userName)
        {
            var userRequest = _userService.GetUser(userName);
            return Task.FromResult(userRequest != null ? MappUser(userRequest) : default(MyUser));
        }

        public Task UpdateAsync(MyUser user)
        {
            //Update database
            return Task.FromResult(0);
        }

        public void Dispose()
        {
        }
        #endregion

        //NOT REQUIRED AT THIS TIME
        #region IUserLoginStore
        public Task AddLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserRoleStore
        public Task AddToRoleAsync(MyUser user, string roleName)
        {
            if (!user.Roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)))
            {
                //update database
                user.Roles.Remove(roleName);
            }

            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(MyUser user)
        {
            return Task.FromResult((IList<string>)user.Roles);
        }

        public Task<bool> IsInRoleAsync(MyUser user, string roleName)
        {
            var roleExists = user.Roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            return Task.FromResult(roleExists);
        }

        public Task RemoveFromRoleAsync(MyUser user, string roleName)
        {
            var removed = user.Roles.Remove(roleName);
            if (removed)
            {
                //update database
            }

            return Task.FromResult(0);
        }
        #endregion

        #region IUserPasswordStore
        public Task<string> GetPasswordHashAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.Password);

            var id = int.Parse(user.Id);
            var passwordHash = _userService.GetUserPasswordHash(id);
            return Task.FromResult(passwordHash);
        }

        public Task<bool> HasPasswordAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(!string.IsNullOrWhiteSpace(user.Password));

            var id = int.Parse(user.Id);
            var passwordHash = _userService.GetUserPasswordHash(id);
            return Task.FromResult(!string.IsNullOrWhiteSpace(passwordHash));
        }

        public Task SetPasswordHashAsync(MyUser user, string passwordHash)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserPasswordHash(id, passwordHash);
            }

            user.Password = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore
        public Task<string> GetSecurityStampAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.SecurityStamp);

            var id = int.Parse(user.Id);
            var securityStamp = _userService.GetUserSecurityStamp(id);
            return Task.FromResult(securityStamp);
        }


        public Task SetSecurityStampAsync(MyUser user, string stamp)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserSecurityStamp(id, stamp);
            }

            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserEmailStore
        public Task<MyUser> FindByEmailAsync(string email)
        {
            var userRequest = _userService.GetUser(email);
            return Task.FromResult(userRequest != null ? MappUser(userRequest) : default(MyUser));
        }

        public Task<string> GetEmailAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.UserName);

            var id = int.Parse(user.Id);
            var email = _userService.GetUserEmail(id);
            return Task.FromResult(email);
        }

        public Task<bool> GetEmailConfirmedAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.EmailVerified);

            var id = int.Parse(user.Id);
            var emailVerified = _userService.GetUserEmailVerified(id);
            return Task.FromResult(emailVerified);
        }

        public Task SetEmailAsync(MyUser user, string email)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserEmail(id, email);
            }

            user.UserName = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(MyUser user, bool confirmed)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserEmailVerified(id, confirmed);
            }

            user.EmailVerified = confirmed;
            return Task.FromResult(0);
        }
        #endregion

        //NOT REQUIRED AT THIS TIME
        #region IUserLockoutStore
        public Task<int> GetAccessFailedCountAsync(MyUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(MyUser user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(MyUser user, bool enabled)
        {
            throw new NotImplementedException();
            //return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(MyUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }
        #endregion

        //NOT REQUIRED AT THIS TIME
        #region IUserTwoFactorStore
        public Task<bool> GetTwoFactorEnabledAsync(MyUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetTwoFactorEnabledAsync(MyUser user, bool enabled)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IClaimsIdentityFactory
        public Task<ClaimsIdentity> CreateAsync(UserManager<MyUser, string> manager, MyUser user, string authenticationType)
        {
            var claimIdentity = new ClaimsIdentity(authenticationType, ClaimTypes.Name, ClaimTypes.Role);
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id, ClaimValueTypes.String));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName, ClaimValueTypes.String));
            foreach (var role in user.Roles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String));
            }

            claimIdentity.AddClaim(new Claim(CustomClaims.Firstname, user.Fullname, ClaimValueTypes.String));

            return Task.FromResult(claimIdentity);
        }
        #endregion

        #region IUserPhoneNumberStore
        public Task<string> GetPhoneNumberAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.Phone);

            var id = int.Parse(user.Id);
            var userPhoneNumber = _userService.GetUserPhone(id);
            return Task.FromResult(userPhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(MyUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Id)) return Task.FromResult(user.PhoneVerified);

            var id = int.Parse(user.Id);
            var phoneVerified = _userService.GetUserPhoneVerified(id);
            return Task.FromResult(phoneVerified);
        }

        public Task SetPhoneNumberAsync(MyUser user, string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserPhone(id, phoneNumber);
            }

            user.Phone = phoneNumber;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberConfirmedAsync(MyUser user, bool confirmed)
        {
            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                var id = int.Parse(user.Id);
                _userService.SetUserPhoneVerified(id, confirmed);
            }

            user.PhoneVerified = confirmed;
            return Task.FromResult(0);
        }
        #endregion

        public static MyUser MappUser(User record)
        {
            var result = new MyUser()
            {
                Id = record.Id,
                Firstname = record.Firstname,
                Lastname = record.Lastname,
                Phone = record.Phone,
                UserName = record.UserName,
                Password = record.Password,
                Active = record.Active,
                SecurityStamp = record.SecurityStamp,
                EmailVerified = record.EmailVerified,
                PhoneVerified = record.PhoneVerified,
                CreatedOn = record.CreatedOn,
                Deleted = record.Deleted,
                Roles = record.UserRoles.Select(r => r.Name).Distinct().ToList(),
            };

            return result;
        }
    }
}
