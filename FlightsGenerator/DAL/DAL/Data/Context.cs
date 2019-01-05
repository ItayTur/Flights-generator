using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    /// <summary>
    /// Entity Framework context class.
    /// </summary>
    public class Context: DbContext
    {
        public DbSet<PlainModel> Plains { get; set; }
        public DbSet<FlightModel> Flights { get; set; }
        public DbSet<StationModel> Stations { get; set; }

        public Context() : base("DbConnectionString")
        {
            // The SetInitializer method is used 
            // to configure EF to use our custom database initializer class
            // which contains our app's seed data.
            Database.SetInitializer(new DatabaseInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Using the fluent API to configure the connection
            // between the stations and their next stations in the strip.
            modelBuilder.Entity<StationModel>()
                .HasMany(s => s.NextDepartureStations)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("StationId");
                    m.MapRightKey("NextStationId");
                    m.ToTable("DepartureStationsRelation");
                });

            modelBuilder.Entity<StationModel>()
                .HasMany(s => s.NextLandingStations)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("StationId");
                    m.MapRightKey("NextStationId");
                    m.ToTable("LandingStationsRelation");
                });
        }
    }
}
