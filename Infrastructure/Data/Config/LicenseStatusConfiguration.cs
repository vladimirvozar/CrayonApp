using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class LicenseStatusConfiguration : IEntityTypeConfiguration<LicenseStatus>
    {
        public void Configure(EntityTypeBuilder<LicenseStatus> builder)
        {
            builder.ToTable("LicenseStatus");

            builder.HasKey(ls => ls.Id);

            builder.Property(ls => ls.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(ls => ls.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
