
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Domen
{
    public class MyDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<EmployeeInfo> Employee { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "k4636402-eu9b-4aa3-h242-a8fbc26f2200",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "a90494b4-dad6-4288-adc2-e970281bdf3f                                                                                                                                                      ",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "qwerty"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "k4636402-eu9b-4aa3-h242-a8fbc26f2200",
                UserId = "a90494b4-dad6-4288-adc2-e970281bdf3f"
            });

            modelBuilder.Entity<EmployeeInfo>().HasData(new EmployeeInfo
            {
                ID = Guid.NewGuid(),
                Name = "name 1",
                Gender = "Man",
                Company ="Company 1",
                Department = "Dep 1"
            });
            modelBuilder.Entity<EmployeeInfo>().HasData(new EmployeeInfo
            {
                ID = Guid.NewGuid(),
                Name = "name 2",
                Gender = "Man",
                Company ="Company 2",
                Department = "Dep 1"
            });
            modelBuilder.Entity<EmployeeInfo>().HasData(new EmployeeInfo
            {
                ID = Guid.NewGuid(),
                Name = "name 3",
                Gender = "Woman",
                Company ="Company 2",
                Department = "Dep 1"
            });

        }
    }
}
