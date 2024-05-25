using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SoftwareLicenseStatusConfiguration : IEntityTypeConfiguration<SoftwareLicenseStatus>
    {
        public void Configure(EntityTypeBuilder<SoftwareLicenseStatus> builder)
        {
            builder.ToTable("SoftwareLicenseStatus");

            builder.HasKey(sls => new { sls.SoftwareLicenseId, sls.LicenseStatusId });

            builder.HasOne(sls => sls.SoftwareLicense)
                .WithMany(sl => sl.SoftwareLicenseStatuses)
                .HasForeignKey(sls => sls.SoftwareLicenseId);

            builder.HasOne(sls => sls.LicenseStatus)
                .WithMany(sl => sl.SoftwareLicenseStatuses)
                .HasForeignKey(sls => sls.LicenseStatusId);
        }
    }
}
