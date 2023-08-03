using Automarket.Domain.Entities;
using Automarket.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Infrastructure.EF.Configurations
{
    internal sealed class ApplicationDbConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(q => q.Id);

            var carBodyConverter = new ValueConverter<CarBody, string>(cb => cb.Value, 
                cb => new CarBody(cb));

            var carBrandConverter = new ValueConverter<CarBrand, string>(b => b.Value,
                b => new CarBrand(b));
            
            var carModelConverter = new ValueConverter<CarModel, string>(m => m.Value,
                m => new CarModel(m));

            var carYearConverter = new ValueConverter<CarYear, int>(y => y.Value,
                y => new CarYear(y));

            builder
                .Property(ad => ad.CarBody)
                .HasConversion(carBodyConverter);

            builder
                .Property(ad => ad.Brand)
                .HasConversion(carBrandConverter);

            builder
                .Property(ad => ad.Model)
                .HasConversion(carModelConverter);

            builder
                .Property(ad => ad.Year)
                .HasConversion(carYearConverter);

        }
    }
}
