using System.Data.Entity;
using Identity.DataLibrary.Mappings;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.IdentityContext
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(string nameOrConnectionString) : base(nameOrConnectionString) 
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMapping());
			modelBuilder.Configurations.Add(new RoleMapping());
			modelBuilder.Configurations.Add(new UserRoleMapping());
        }
    }
}