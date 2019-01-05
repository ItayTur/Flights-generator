using Common.Args;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface to be implamented by WaitingStationManager
    /// </summary>
    public interface IWaitingStationsManager
    {

        /// <summary>
        /// Addes a flight to the waiting list of one of the base stations.
        /// </summary>
        /// <param name="flight">The FlightModel instance to be inserted the waiting list</param>
        void AddNewFlight(FlightModel flight);


        /// <summary>
        /// Register a function to be called when the flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        void RegisterToFlightEvent(FlightEventHandler onFlightEvent);
    }
}
