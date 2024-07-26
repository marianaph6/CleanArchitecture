using CleanArchitecture.Identity.Configurations;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity
{
    public class CleanArquitectureIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CleanArquitectureIdentityDbContext(DbContextOptions<CleanArquitectureIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

            builder.Entity<ApplicationUser>()
               .Property(u => u.AccessFailedCount)
               .HasDefaultValue(0);

            builder.Entity<ApplicationUser>()
               .Property(u => u.LockoutEnabled)
               .HasDefaultValue(false);

            builder.Entity<ApplicationUser>()
               .Property(u => u.PhoneNumberConfirmed)
               .HasDefaultValue(false);

            builder.Entity<ApplicationUser>()
               .Property(u => u.TwoFactorEnabled)
               .HasDefaultValue(false);
        }
    }
}