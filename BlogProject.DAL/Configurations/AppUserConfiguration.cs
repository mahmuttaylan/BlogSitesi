using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new AppUser
            {
                Id = 1,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+905376112122",
                FirstName = "Cevdet",
                LastName = "Herodot",
                About = "Sistemin en yetkili admini.",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "user-images/usericon.png"

            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");

            var author1 = new AppUser
            {
                Id = 2,
                UserName = "mahmut@gmail.com",
                NormalizedUserName = "MAHMUT@GMAIL.COM",
                Email = "mahmut@gmail.com",
                NormalizedEmail = "MAHMUT@GMAIL.COM",
                PhoneNumber = "+905556667788",
                FirstName = "Mahmut",
                LastName = "Taylan",
                About = "Sitenin kıdemli yazar kadrosuna dahil.",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "user-images/Mahmut.jpg"
            };
            author1.PasswordHash = CreatePasswordHash(author1, "123456");

            var author2 = new AppUser
            {
                Id = 3,
                UserName = "dursun@gmail.com",
                NormalizedUserName = "DURSUN@GMAIL.COM",
                Email = "dursun@gmail.com",
                NormalizedEmail = "DURSUN@GMAIL.COM",
                PhoneNumber = "+905537611222",
                FirstName = "Dursun",
                LastName = "Durmasin",
                About = "Sitenin kıdemli yazar kadrosuna dahil.",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "user-images/usericon.png"
            };
            author2.PasswordHash = CreatePasswordHash(author2, "123456");

            var author3 = new AppUser
            {
                Id = 4,
                UserName = "Kamil@gmail.com",
                NormalizedUserName = "KAMIL@GMAIL.COM",
                Email = "kamil@gmail.com",
                NormalizedEmail = "KAMIL@GMAIL.COM",
                PhoneNumber = "+905556667788",
                FirstName = "Kamil",
                LastName = "Kamil",
                About = "Sitenin kıdemli yazar kadrosuna dahil.",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "user-images/usericon.png"
            };
            author3.PasswordHash = CreatePasswordHash(author3, "123456");

            builder.HasData(admin, author1, author2, author3);
        }

        private string CreatePasswordHash(AppUser appUser, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(appUser, password);
        }
    }
}
