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
    public class CafeConfiguration : IEntityTypeConfiguration<Cafe>
    {
        public void Configure(EntityTypeBuilder<Cafe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50);  

            builder.Property(x => x.Monthly_Rent).HasPrecision(10,2);

            builder.Property(x=>x.Rent_Duration).IsRequired();  

           
        }
    }
}
