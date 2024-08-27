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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x => x.Id);

          
           
            builder.Property(x => x.Type).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PricePerKilo).HasPrecision(10, 2);

            //relation between food and imports

            builder.HasOne(e => e.imports).WithOne(e => e.Foods).HasForeignKey<Food>(e=>e.importsId).IsRequired();
            builder.HasIndex(x => x.importsId).IsUnique();

        }
    }
}
