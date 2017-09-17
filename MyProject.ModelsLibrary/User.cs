using System;
using System.Collections.Generic;
using Identity.ModelsLibrary.Records.Identities;

namespace Identity.ModelsLibrary
{
    public class User
    {
        private string _profilePic;
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }
        public bool Active { get; set; }
        public string ProfilePic
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_profilePic) ? _profilePic : "/images/user-default.png";
            }
            set
            {
                _profilePic = value;
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string SecurityStamp { get; set; }
        public bool EmailVerified { get; set; }
        public bool PhoneVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Deleted { get; set; }
        public List<string> Roles { get; set; }
        public List<RecordIdentity> UserRoles { get; set; }//Used when creating/updating record

        public User()
        {
            Roles = new List<string>();
            UserRoles = new List<RecordIdentity>();
        }
    }
}
