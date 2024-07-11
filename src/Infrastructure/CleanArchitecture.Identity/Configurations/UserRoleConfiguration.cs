using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "243e4e3e-626f-40c2-9e01-34fd8842608f",
                    UserId = "c16bc907-86de-4762-b334-d0c923588ffc"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "caae4db2-3047-48ca-855f-3fc91e0c89ac",
                    UserId = "171e0aac-219c-495b-8979-61c0ece2572f"
                }
            ); ;
        }
    }
}
