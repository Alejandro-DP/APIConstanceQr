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
            modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            

        }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Users_Courses> Users_Courses { get; set; }
        public virtual DbSet<Carrer> Carrers { get; set; }
      
    }
  
}
