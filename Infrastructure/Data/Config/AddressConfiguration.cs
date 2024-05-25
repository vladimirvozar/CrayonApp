using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(add => add.Id);

            builder.Property(add => add.City)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(add => add.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(add => add.State)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(add => add.State)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
