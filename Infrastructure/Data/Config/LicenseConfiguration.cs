using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class LicenseConfiguration : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.ToTable("License");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(l => l.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.Price)
                .IsRequired();

            builder.Property(l => l.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(l => l.SoftwareProduct)
                .WithMany(sp => sp.Licenses)
                .HasForeignKey(l => l.SoftwareProductId);
        }
    }
}
