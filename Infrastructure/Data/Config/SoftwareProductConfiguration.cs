using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SoftwareProductConfiguration : IEntityTypeConfiguration<SoftwareProduct>
    {
        public void Configure(EntityTypeBuilder<SoftwareProduct> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(sp => sp.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sp => sp.Description)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
