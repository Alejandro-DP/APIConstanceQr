using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class CourseConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)//indices 
        {
            builder.HasIndex(e => e.UserId).HasDatabaseName("IU_confUsuario");
            builder.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
