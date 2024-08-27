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
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(x => x.Id);  
            
            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasColumnType("VARCHAR").HasMaxLength(100);


            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50);
           
        }
    }
}
