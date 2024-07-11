using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new
                {
                    Id = "c16bc907-86de-4762-b334-d0c923588ffc",
                    Email = "mariana1996.mph@gmail.com",
                    NormalizedEmail = "mariana1996.mph@gmail.com",
                    Nombre = "Mariana",
                    Apellidos = "Palacios",
                    UserName = "mariana1996.mph",
                    NormalizedUserName = "mariana1996.mph",
                    PasswordHash = hasher.HashPassword(null, "mariana1996mph*"),
                    EmailConfirmed = true

                },
                new
                {
                    Id = "171e0aac-219c-495b-8979-61c0ece2572f",
                    Email = "mariana458@hotmail.com",
                    NormalizedEmail = "mariana458@hotmail.com",
                    Nombre = "Mariana",
                    Apellidos = "Hinestroza",
                    UserName = "mariana458",
                    NormalizedUserName = "mariana458",
                    PasswordHash = hasher.HashPassword(null, "mariana458*"),
                    EmailConfirmed = true

                }
            ); ;
        }
    }
}
