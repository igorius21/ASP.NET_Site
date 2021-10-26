using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyProject.Domain.Entities;

namespace StudyProject.Domain
{
    public class ContextDb : IdentityDbContext<IdentityUser>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<Text> Text { get; set; }
        public DbSet<MyService> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder mod)
        {
            base.OnModelCreating(mod);

            mod.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "C4C4A1B3-1A47-49A5-A418-E5DD52BC9308",
                Name = "admin",
            });

            mod.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "1C077DC9-3F0B-4652-8B22-A41ABF0D1CEC",
                UserName = "admin",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            mod.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "C4C4A1B3-1A47-49A5-A418-E5DD52BC9308",
                UserId = "1C077DC9-3F0B-4652-8B22-A41ABF0D1CEC"
            });

            mod.Entity<Text>().HasData(new Text
            {
                Id = new Guid("BFE58F1B-66DD-4228-906C-3C9DCB7B546E"),
                KeyWord = "PageIndex",
                Title = "Главная"
            });
            mod.Entity<Text>().HasData(new Text
            {
                Id = new Guid("B47E8BAF-BE88-4F27-9E26-AF1B5F5F19B5"),
                KeyWord = "PageServices",
                Title = "Услуги компании"
            });
            mod.Entity<Text>().HasData(new Text
            {
                Id = new Guid("FC9A5DA1-CCAD-45E6-890A-15B6FAD05DA8"),
                KeyWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}

