using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Repository interface class that provides various database queries
    /// and CRUD operations.
    /// </summary>
    public interface IFlightsRepository
    {
        /// <summary>
        /// Returns an enumerator of flights.
        /// </summary>
        /// <returns>An IEnumerable collection of FlightModel entity instances include their planes.</returns>
        IEnumerable<FlightModel> GetAll();


        /// <summary>
        /// Gets the flight associated with the spcified ID.
        /// </summary>
        /// <param name="flightId">The flight ID to retrieve.</param>
        /// <returns>A fully populated FlightModel entity instance.</returns>
        FlightModel GetFlight(int flightId);


        /// <summary>
        /// Adds a flight.
        /// </summary>
        /// <param name="flight">The FlightModel entity instance to add.</param>
        /// <returns>A fully populated FlightModel entity instance.</returns>
        FlightModel Add(FlightModel flight);


        /// <summary>
        /// Update the flight associated with the spcified FlightModel instance.
        /// </summary>
        /// <param name="flight">The FlightModel entity instance to update.</param>
        void Update(FlightModel flight);


        /// <summary>
        /// Removes the flight associated with the spcified ID.
        /// </summary>
        /// <param name="flightId">The flight ID to remove.</param>
        void Remove(int flightId);
    }
}
