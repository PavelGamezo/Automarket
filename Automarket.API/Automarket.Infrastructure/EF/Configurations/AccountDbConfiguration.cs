using Automarket.Domain.Account.Entities;
using Automarket.Domain.Account.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Automarket.Infrastructure.EF.Configurations
{
    internal sealed class AccountDbConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.Id);

            var accountLoginConverter = new ValueConverter<Login, string>(l => l.Value,
                l => new Login(l));
            
            var accountPasswordConverter = new ValueConverter<Password, string>(p => p.Value,
                p => new Password(p));

            var accountFullNameConverter = new ValueConverter<AccountFullName, string>(fn => fn.ToString(),
                fn => AccountFullName.Create(fn));

            builder
                .Property(a => a.FullName)
                .HasConversion(accountFullNameConverter);

            builder
                .Property(a=> a.Password)
                .HasConversion(accountPasswordConverter);

            builder
                .Property(a => a.Login)
                .HasConversion(accountLoginConverter);

            builder
                .HasMany(a => a.Ads)
                .WithOne(a => a.Account);
        }
    }
}
