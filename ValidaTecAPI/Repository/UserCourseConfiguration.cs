using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<Users_Courses>
    {
        public void Configure(EntityTypeBuilder<Users_Courses> builder)
        {
            
        }
    }
}
