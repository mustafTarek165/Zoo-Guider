using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.Entities
{
    public class Ticket_Reservation
    {
        public int Id { get; set; } 
        public DateTime DateOfReservation { get; set; }
        public string ?TicketType { get; set; }
        public double Price { get; set; }       
       
    }
}
