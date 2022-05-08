using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class CourseConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)//indices 
        {
           
            builder.HasIndex(e => e.CarrerId).HasDatabaseName("IU_Carrer_Course");
            builder.HasOne(typeof(Carrer)).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
