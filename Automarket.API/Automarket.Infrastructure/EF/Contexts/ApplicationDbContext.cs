using Automarket.Domain.Entities;
using Automarket.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Infrastructure.EF.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ApplicationDbConfiguration();
            modelBuilder.ApplyConfiguration<Ad>(configuration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
