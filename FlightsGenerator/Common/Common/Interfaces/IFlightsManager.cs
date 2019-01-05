using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// The main manager invoking the flights events.
    /// </summary>
    public interface IFlightsManager
    {

        /// <summary>
        /// Adds a flight.
        /// </summary>
        /// <param name="flight">The FlightModel instance to add the database and the time manager queue.</param>
        FlightModel AddFlight(FlightModel flight);


        /// <summary>
        /// Returns an enomrator collection of flights.
        /// </summary>
        /// <returns>An enomrator collection of FlightModel instances.</returns>
        IEnumerable<FlightModel> GetAll();


        /// <summary>
        /// Register a function to be called when the flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        void RegisterToFlightStartEvent(FlightEventHandler onFlightStart);


        /// <summary>
        /// Returns an enomrator collection of stations.
        /// </summary>
        /// <returns>An enomrator collection of StationModel entity instances including their next in line stations .</returns>
        IEnumerable<StationModel> GetStations();
    }
}
