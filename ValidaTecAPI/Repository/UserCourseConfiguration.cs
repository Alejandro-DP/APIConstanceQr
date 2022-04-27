using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<Users_Courses>
    {
        public void Configure(EntityTypeBuilder<Users_Courses> builder)
        {
            builder.HasIndex(h => h.UserId).HasDatabaseName("IU_UserCourse_User");
            builder.HasIndex(h => h.CourseId).HasDatabaseName("IU_UserCourse_Course");

            builder.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(typeof(Courses)).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
