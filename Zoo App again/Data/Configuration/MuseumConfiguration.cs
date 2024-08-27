using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_App_again.Entities;

namespace Zoo_App_again.Data.Configuration
{
    public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
    {
        public void Configure(EntityTypeBuilder<Museum> builder)
        {
          builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Founder).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            
        }
    }
}
