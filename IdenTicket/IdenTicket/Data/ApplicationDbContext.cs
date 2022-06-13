using IdenTicket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdenTicket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AirLine> AirLines { get; set; }
        public DbSet<AirplaneModel> AirplaneModels { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightLeg> FlightLegs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var airlines = builder.Entity<AirLine>();
            var airplaneModels = builder.Entity<AirplaneModel>();
            var airports = builder.Entity<Airport>();
            var flights = builder.Entity<Flight>();
            var flightLegs = builder.Entity<FlightLeg>();
            var tickets = builder.Entity<Ticket>();

            flightLegs.HasKey(fl => new { fl.FlightId, fl.Direction, fl.LegNumber });
            flightLegs.HasOne(fl => fl.Flight)
                .WithMany(f => f.FlightLegs)
                .HasForeignKey(fl => fl.FlightId);
            flightLegs.HasOne(fl => fl.AirLine)
                .WithMany(al => al.FlightLegs)
                .HasForeignKey(fl => fl.AirLineId);
            flightLegs.HasOne(fl => fl.AirplaneModel)
                .WithMany(am => am.FlightLegs)
                .HasForeignKey(fl => fl.AirplaneModelId);
        }
    }
}
