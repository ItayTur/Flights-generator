using Common.Interfaces;
using Common.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SqlRepositories
{
    /// <summary>
    /// Repository class that provides various database queries
    /// and CRUD operations.
    /// </summary>
    public class SqlFlightsRepository : IFlightsRepository
    {


        /// <summary>
        /// Adds a flight.
        /// </summary>
        /// <param name="flight">The FlightModel entity instance to add.</param>
        /// <returns>A fully populated FlightModel entity instance.</returns>
        public FlightModel Add(FlightModel flight)
        {
            using (Context context = new Context())
            {
                context.Flights.Add(flight);
                context.SaveChanges();

                return flight;
            }
        }


        /// <summary>
        /// Gets an enumerator of all the flights.
        /// </summary>
        /// <returns>A list of FlightModel entity instances including their planes.</returns>
        public IEnumerable<FlightModel> GetAll()
        {
            using (Context context = new Context())
            {
                var flights = context.Flights.Include(f=>f.Plain).ToList();

                return flights;
            }
        }


        /// <summary>
        /// Gets the flight associated with the spcified ID.
        /// </summary>
        /// <param name="flightId">The flight ID to retrieve.</param>
        /// <returns>A fully populated FlightModel entity instance.</returns>
        public FlightModel GetFlight(int flightId)
        {
            using (Context context = new Context())
            {
                return context.Flights.Find(flightId);
            }
        }


        /// <summary>
        /// Removes the flight associated with the spcified ID.
        /// </summary>
        /// <param name="flightId">The flight ID to remove.</param>
        public void Remove(int flightId)
        {
            using (Context context = new Context())
            {
                FlightModel flight = context.Flights.Find(flightId);
                context.Flights.Remove(flight);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Updates the flight associated with the spcified FlightModel instance.
        /// </summary>
        /// <param name="flight">The FlightModel entity instance to update.</param>
        public void Update(FlightModel flight)
        {
            using (Context context = new Context())
            {
                context.Flights.Attach(flight);
                context.Entry(flight).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
