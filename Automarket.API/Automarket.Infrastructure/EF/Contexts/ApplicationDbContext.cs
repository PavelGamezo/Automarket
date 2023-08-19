using Automarket.Domain.Account.Entities;
using Automarket.Domain.AccountAd.Entities;
using Automarket.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Infrastructure.EF.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adConfiguration = new AdDbConfiguration();
            var accountConfiguration = new AccountDbConfiguration();

            modelBuilder.ApplyConfiguration<Ad>(adConfiguration);
            modelBuilder.ApplyConfiguration<Account>(accountConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
