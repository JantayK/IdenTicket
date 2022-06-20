using IdenTicket.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<SearchLog> SearchLogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var users = builder.Entity<IdentityUser>();
            var userClaims = builder.Entity<IdentityUserClaim<string>>();
            var userLogins = builder.Entity<IdentityUserLogin<string>>();
            var userRoles = builder.Entity<IdentityUserRole<string>>();
            var userTokens = builder.Entity<IdentityUserToken<string>>();
            var roles = builder.Entity<IdentityRole>();
            var roleClaims = builder.Entity<IdentityRoleClaim<string>>();

            var airLines = builder.Entity<AirLine>();
            var airports = builder.Entity<Airport>();
            var flightLegs = builder.Entity<FlightLeg>();
            var tickets = builder.Entity<Ticket>();
            var customers = builder.Entity<Customer>();
            var searchLogs = builder.Entity<SearchLog>();

            users.ToTable("Users");
            users.Property(u => u.UserName).IsRequired();
            users.Property(u => u.Email).IsRequired();
            users.Property(u => u.PasswordHash).IsRequired();

            customers.Property(c => c.FirstName).IsRequired();
            customers.Property(c => c.LastName).IsRequired();
            customers.Property(c => c.DateOfBirth).IsRequired();
            customers.Property(c => c.PassportNumber).IsRequired();
            customers.HasOne(c => c.Country)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            userClaims.ToTable("UserClaims");
            userClaims.Property(c => c.ClaimType).IsRequired();

            userLogins.ToTable("UserLogins");
            userRoles.ToTable("UserRoles");
            userTokens.ToTable("UserTokens");

            roles.ToTable("Roles");
            roles.Property(c => c.Name).IsRequired();

            roleClaims.ToTable("RoleClaims");
            roleClaims.Property(c => c.ClaimType).IsRequired();

            airLines.HasOne(al => al.Country)
                .WithMany(c => c.AirLines)
                .HasForeignKey(al => al.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            airports.HasOne(a => a.City)
                .WithMany(c => c.Airports)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            tickets.Property(t => t.CustomerId).IsRequired();
            tickets.HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            flightLegs.HasKey(fl => new { fl.FlightId, fl.Direction, fl.LegNumber });
            flightLegs.HasOne(fl => fl.Flight)
                .WithMany(f => f.FlightLegs)
                .HasForeignKey(fl => fl.FlightId)
                .OnDelete(DeleteBehavior.Restrict);
            flightLegs.HasOne(fl => fl.DepartAirport)
                .WithMany(a => a.FlightLegsToDepart)
                .HasForeignKey(fl => fl.DepartAirportId)
                .OnDelete(DeleteBehavior.Restrict);
            flightLegs.HasOne(fl => fl.ArriveAirport)
                .WithMany(a => a.FlightLegsToArrive)
                .HasForeignKey(fl => fl.ArriveAirportId)
                .OnDelete(DeleteBehavior.Restrict);
            flightLegs.HasOne(fl => fl.AirLine)
                .WithMany(a => a.FlightLegs)
                .HasForeignKey(fl => fl.AirLineId)
                .OnDelete(DeleteBehavior.Restrict);
            flightLegs.HasOne(fl => fl.AirplaneModel)
                .WithMany(a => a.FlightLegs)
                .HasForeignKey(fl => fl.AirplaneModelId)
                .OnDelete(DeleteBehavior.Restrict);

            searchLogs.HasOne(sl => sl.Customer)
                .WithMany(c => c.SearchLogs)
                .HasForeignKey(sl => sl.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
