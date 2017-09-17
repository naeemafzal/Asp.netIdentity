using System.Data.Entity.ModelConfiguration;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.Mappings
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping()
        {
            ToTable("UserRoles");
            HasKey(e => new { e.UserId, e.RoleId });
			HasRequired(e => e.User).WithMany(e => e.UserRole).HasForeignKey(e => e.UserId);
			HasRequired(e => e.Role).WithMany(e => e.UserRole).HasForeignKey(e => e.RoleId);
        }
    }
}