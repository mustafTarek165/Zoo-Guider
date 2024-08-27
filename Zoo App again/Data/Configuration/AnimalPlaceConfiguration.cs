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
    public class AnimalPlaceConfiguration : IEntityTypeConfiguration<AnimalPlace>
    {
        public void Configure(EntityTypeBuilder<AnimalPlace> builder)
        {
            builder.HasKey(x => x.Id);
          
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();

        }
    }
}
