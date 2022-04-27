using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidaTecAPI.Models;

namespace ValidaTecAPI.Repository
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.RoleId).HasDatabaseName("UI_Usuario");
            builder.HasMany(typeof(Role)).WithOne().OnDelete(DeleteBehavior.Restrict);
            //builder.HasIndex(u => new { u.UserId, u.RoleId }).HasDatabaseName("UI_UsuarioRol").IsUnique();

            //builder.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(typeof(Role)).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.CarrerId).HasDatabaseName("UI_Carrer_User");
            builder.HasMany(typeof(Carrer)).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
