using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(256);

            builder.Property(u => u.Surname)
                .HasMaxLength(256);

            builder.Property(u => u.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(11);

            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.Property(u => u.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(u => u.UpdatedAt)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
