using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Data.Configurations
{
    public class LoginCodeConfiguration : IEntityTypeConfiguration<LoginCode>
    {
        public void Configure(EntityTypeBuilder<LoginCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.Code)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
        }
    }
}
