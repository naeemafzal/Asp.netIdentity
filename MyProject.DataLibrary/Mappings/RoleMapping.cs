using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.Mappings
{
    public class RoleMapping : BaseMapping<Role>
    {
        public RoleMapping()
        {
            ToTable("Roles");
            Property(e => e.Name).HasColumnName("Name").HasMaxLength(300).IsRequired().IsUnicode(false);
        }
    }
}