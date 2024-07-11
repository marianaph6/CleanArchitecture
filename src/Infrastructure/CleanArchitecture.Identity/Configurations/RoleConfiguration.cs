using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new
                {
                    Id = "243e4e3e-626f-40c2-9e01-34fd8842608f",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new
                {
                    Id = "caae4db2-3047-48ca-855f-3fc91e0c89ac",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }

                );
        }
    }
}
