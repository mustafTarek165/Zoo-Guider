using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_App_again.Entities;

namespace Zoo_App_again.Data
{
    public class AppDbContext:DbContext
    {
       public DbSet<Registration> Registrations { get; set; }  
       public DbSet<Food> Foods { get; set; }  
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Cafe> Cafes { get; set; } 
        public DbSet<Exports> OurExports { get; set; }    
        public DbSet<Imports> OurImports { get; set; }

        public DbSet<Museum> Museums { get; set; }
        public DbSet<Ticket_Reservation> Ticket_Reservations { get; set; } 
        public DbSet<AnimalPlace> AnimalPlaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionstring = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(connectionstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
