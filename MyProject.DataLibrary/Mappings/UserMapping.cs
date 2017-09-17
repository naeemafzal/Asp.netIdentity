using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.Mappings
{
    public class UserMapping : BaseMapping<User>
    {
        public UserMapping()
        {
            ToTable("Users");
            Property(e => e.Active).HasColumnName("Active").IsRequired();
            Property(e => e.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(e => e.Deleted).HasColumnName("Deleted").IsRequired();
            Property(e => e.EmailVerified).HasColumnName("EmailVerified").IsRequired();
            Property(e => e.Firstname).HasColumnName("Firstname").HasMaxLength(300).IsRequired().IsUnicode(true);
            Property(e => e.Lastname).HasColumnName("Lastname").HasMaxLength(300).IsRequired().IsUnicode(true);
            Property(e => e.Password).HasColumnName("Password").IsRequired().IsUnicode(true);
            Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(50).IsOptional().IsUnicode(true);
            Property(e => e.PhoneVerified).HasColumnName("PhoneVerified").IsRequired();
            Property(e => e.ProfilePic).HasColumnName("ProfilePic").HasMaxLength(500).IsOptional().IsUnicode(true);
            Property(e => e.SecurityStamp).HasColumnName("SecurityStamp").IsRequired().IsUnicode(true);
            Property(e => e.Username).HasColumnName("Username").HasMaxLength(300).IsRequired().IsUnicode(true);
        }
    }
}