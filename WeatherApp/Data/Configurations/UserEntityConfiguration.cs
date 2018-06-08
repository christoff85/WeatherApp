using System.Data.Entity.ModelConfiguration;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Configurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            ToTable("Users");

            Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);

            HasIndex(p => p.UserName)
                .IsUnique();
        }
    }
}