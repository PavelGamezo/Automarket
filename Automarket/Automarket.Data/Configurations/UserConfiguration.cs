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
    /*public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(q => q.UserId);

            builder.Property(q => q.Nickname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(q => q.Email)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }*/
}
