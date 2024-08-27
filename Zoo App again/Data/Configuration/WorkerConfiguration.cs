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
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x=>x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Job).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            
            builder.Property(x => x.Salary).HasPrecision(10, 2);

        }
    }
}
