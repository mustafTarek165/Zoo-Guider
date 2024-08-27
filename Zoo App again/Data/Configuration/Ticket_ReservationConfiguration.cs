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
    public class Ticket_ReservationConfiguration : IEntityTypeConfiguration<Ticket_Reservation>
    {
        public void Configure(EntityTypeBuilder<Ticket_Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.TicketType).HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
