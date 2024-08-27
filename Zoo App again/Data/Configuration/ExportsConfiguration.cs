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
    public class ExportsConfiguration : IEntityTypeConfiguration<Exports>
    {
        public void Configure(EntityTypeBuilder<Exports> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Country).HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();

            builder.Property(x => x.OrganizationExportedTo).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();

            builder.Property(x => x.Quantity).IsRequired();
           
       
            builder.Property(x => x.Type).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            builder.Property(x => x.HistoryOfProcess).IsRequired();
            builder.Property(x => x.TotalPrice).HasPrecision(10, 2);
            builder.Property(x => x.TotalPrice).IsRequired();
        }
    }
}
