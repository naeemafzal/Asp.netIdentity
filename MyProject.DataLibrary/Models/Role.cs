using System.Collections.Generic;

namespace Identity.DataLibrary.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
		public virtual ICollection<UserRole> UserRole { get; set; }

        public Role()
        {
            UserRole = new List<UserRole>();
        }
    }
}