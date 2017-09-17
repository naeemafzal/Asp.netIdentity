using System;
using System.Collections.Generic;

namespace Identity.DataLibrary.Models
{
    public class User : BaseModel
    {
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Deleted { get; set; }
        public bool EmailVerified { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool PhoneVerified { get; set; }
        public string ProfilePic { get; set; }
        public string SecurityStamp { get; set; }
        public string Username { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        public User()
        {
            UserRole = new List<UserRole>();
        }
    }
}