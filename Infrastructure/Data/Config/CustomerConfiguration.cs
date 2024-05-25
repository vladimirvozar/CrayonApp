using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.MiddleName)
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(c => c.Address)
                .WithMany(add => add.Customers)
                .HasForeignKey(c => c.AddressId);
        }
    }
}
