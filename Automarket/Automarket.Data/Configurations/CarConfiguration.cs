using Automarket.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(q => q.CarId);

            builder.Property(q => q.CarType)
                   .IsRequired();

            builder.Property(q => q.Brand)
                   .IsRequired();

            builder.Property(q => q.Price)
                   .IsRequired();

            builder.Property(q => q.Year)
                   .IsRequired();

            builder.Property(q => q.Description)
                   .IsRequired();

            builder.Property(q => q.Mileage)
                   .IsRequired();

            builder.Property(q => q.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(q => q.User)
                   .WithMany(q => q.Cars);
        }
    }
}
