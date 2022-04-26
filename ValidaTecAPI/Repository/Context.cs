using Microsoft.EntityFrameworkCore;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //model.Entity<User>().HasKey(x => new {x.UserId});
            //model.Entity<User>().HasOne(o => o.UserRole).WithOne().HasForeignKey<User>(o => o.UserId);
            //llaves primarias y relationship 

            modelBuilder.ApplyConfiguration(new CourseConfiguration());

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
    }
  
}
