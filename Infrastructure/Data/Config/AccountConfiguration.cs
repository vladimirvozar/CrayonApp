using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(acc => acc.Id);

            builder.Property(acc => acc.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(acc => acc.AccountType)
                .IsRequired();

            builder.HasOne(acc => acc.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(acc => acc.CustomerId);

        }
    }
}
