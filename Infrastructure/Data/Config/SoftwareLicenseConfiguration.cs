using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SoftwareLicenseConfiguration : IEntityTypeConfiguration<SoftwareLicense>
    {
        public void Configure(EntityTypeBuilder<SoftwareLicense> builder)
        {
            builder.ToTable("SoftwareLicense");

            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.SoftwareName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(sl => sl.SoftwareCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sl => sl.LicenseName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(sl => sl.LicenseCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sl => sl.Quantity)
                .IsRequired();

            builder.HasOne(sl => sl.Account)
                .WithMany(acc => acc.SoftwareLicenses)
                .HasForeignKey(sl => sl.AccountId);
        }
    }
}
