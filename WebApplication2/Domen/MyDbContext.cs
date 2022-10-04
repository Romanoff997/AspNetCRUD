
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Domen
{
    public class MyDbContext: DbContext
    {
        public DbSet<EmployeeInfo> Employee { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
