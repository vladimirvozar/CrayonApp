using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.SoftwareName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(o => o.SoftwareCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.LicenseName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(o => o.LicenseCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.Price)
                .IsRequired();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerId);

            // Order <-> SoftwareLicence
            // 'one-to-one' relation where Order is 'Principal' and SoftwareLicence is 'Dependent'
            builder.HasOne(o => o.SoftwareLicense)
                .WithOne(sl => sl.Order)
                .HasForeignKey<SoftwareLicense>(sl => sl.OrderId);
        }
    }
}
