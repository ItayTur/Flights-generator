using Common.Args;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface to be impalmanted by StationsManager
    /// </summary>
    public interface IStationsManager
    {

        /// <summary>
        /// The function beind called when timer elpased occured.
        /// </summary>
        /// <param name="flight">The FlightModel instance needs to be enter the base station.</param>
        void FlightTimeArrivedEvent(FlightModel flight);


        /// <summary>
        /// Register a function to be called when the flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        void RegisterToFlightStartEvent(FlightEventHandler flightEnterEvent);
    }
}
