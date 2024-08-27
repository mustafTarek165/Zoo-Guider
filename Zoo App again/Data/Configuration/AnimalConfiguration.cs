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
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Classification).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PricePerOne).HasPrecision(10,2).IsRequired();

            //relation between animal and animal place

            builder.HasOne(e => e.AnimalPlace).WithMany(e => e.Existing_Animals).HasForeignKey(e => e.animalPlaceId).IsRequired(false);
            //relation between reptile and imports
            builder.HasOne(e => e.imports).WithOne(e => e.Existing_Animals).HasForeignKey<Animal>(e => e.importsId).IsRequired(false);
        }
    }
}
