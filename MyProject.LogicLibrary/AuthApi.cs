using System;
using System.Linq;
using Identity.DataLibrary.IdentityContext;
using Identity.ModelsLibrary;
using Identity.ModelsLibrary.Records.Identities;
using DataUser = Identity.DataLibrary.Models.User;
using User = Identity.ModelsLibrary.User;

namespace Identity.ApiLibrary
{
    public class AuthApi : BaseApi, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthApi(AppUserInfo appUserInfo) : base(appUserInfo)
        {
            _unitOfWork = new UnitOfWork(new IdentityContext("DefaultConnection"));
        }

        public User GetUser(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId));
        }

        public User GetUser(string username)
        {
            return MapUser(_unitOfWork.Users.GetUser(username));
        }

        public string GetUserPhone(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).Phone;
        }

        public bool GetUserPhoneVerified(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).PhoneVerified;
        }

        public void SetUserPhone(int userId, string phoneNumber)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.Phone = phoneNumber;
            _unitOfWork.Complete();
        }

        public void SetUserPhoneVerified(int userId, bool confirmed)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.PhoneVerified = confirmed;
            _unitOfWork.Complete();
        }

        public User CreateUser(User userEntity)
        {
            var userRecord = MapUser(userEntity, false);
            _unitOfWork.Users.Add(userRecord);
            _unitOfWork.Complete();
            return MapUser(userRecord);
        }

        public string GetUserPasswordHash(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).Password;
        }

        public void SetUserPasswordHash(int userId, string passwordHash)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.Password = passwordHash;
            _unitOfWork.Complete();
        }

        public string GetUserSecurityStamp(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).SecurityStamp;
        }

        public void SetUserSecurityStamp(int userId, string stamp)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.SecurityStamp = stamp;
            _unitOfWork.Complete();
        }

        public string GetUserEmail(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).UserName;
        }

        public bool GetUserEmailVerified(int userId)
        {
            return MapUser(_unitOfWork.Users.GetUser(userId)).EmailVerified;
        }

        public void SetUserEmail(int userId, string email)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.Username = email;
            _unitOfWork.Complete();
        }

        public void SetUserEmailVerified(int userId, bool confirmed)
        {
            var userRecord = _unitOfWork.Users.GetUser(userId);
            userRecord.EmailVerified = confirmed;
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        #region Helpers

        private DataUser MapUser(User user, bool mapId = true)
        {
            if (user == null) return null;
            return new DataUser()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EmailVerified = user.EmailVerified,
                Id = mapId && IsValidInt(user.Id) ? int.Parse(user.Id) : int.Parse("0"),
                Password = user.Password,
                Phone = user.Phone,
                PhoneVerified = user.PhoneVerified,
                SecurityStamp = user.SecurityStamp,
                Username = user.UserName,
                Active = user.Active,
                CreatedOn = user.CreatedOn,
                Deleted = user.Deleted,
                ProfilePic = user.ProfilePic
            };
        }

        private User MapUser(DataUser user, bool mapId = true)
        {
            if (user == null) return null;
            return new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                EmailVerified = user.EmailVerified,
                Id = mapId ? user.Id.ToString() : "0",
                Password = user.Password,
                Phone = user.Phone,
                PhoneVerified = user.PhoneVerified,
                SecurityStamp = user.SecurityStamp,
                UserName = user.Username,
                Active = user.Active,
                CreatedOn = user.CreatedOn,
                Deleted = user.Deleted,
                ProfilePic = user.ProfilePic,
                UserRoles = user.UserRole.Select(r => new RecordIdentity() { Id = r.Role.Id, Name = r.Role.Name }).ToList(),
                Roles = user.UserRole.Select(r => r.Role.Name).ToList()
            };
        }

        private bool IsValidInt(string input)
        {
            int output;
            return int.TryParse(input, out output);
        }
        #endregion
    }
}
