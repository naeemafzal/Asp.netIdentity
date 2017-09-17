namespace Identity.DataLibrary.Models
{
    public class UserRole
    {
        public virtual int RoleId { get; set; }
		public virtual Role Role { get; set; }
		public virtual int UserId { get; set; }
		public virtual User User { get; set; }
    }
}