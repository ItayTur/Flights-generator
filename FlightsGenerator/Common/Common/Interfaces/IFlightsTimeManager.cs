using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{

    /// <summary>
    /// Delegate passing the flight on which the timer set.
    /// </summary>
    public delegate void TimerElapsedEventHandler(FlightModel flight);


    /// <summary>
    /// The Interface need to be implemented by any flights time manager.
    /// </summary>
    public interface IFlightsTimeManager
    {


        /// <summary>
        /// Remove the flight entering the base station.
        /// Reseting the timer to a new flight.
        /// </summary>
        void EnterBaseStation();


        /// <summary>
        /// Adds a flight to the time pueue.
        /// </summary>
        /// <param name="flight">The FlightModel instance to add the the time manager queue.</param>
        void Add(FlightModel flight);


        /// <summary>
        /// Returns the ID of the first flight in the queue.
        /// </summary>
        int GetFirstId();



        /// <summary>
        /// Register a function to be called when timer elapsed.
        /// </summary>
        /// /// <param name="onTimerElapsed">The TimerElapsedEventHandler function registering the flight event.</param>
        void RegisterToTimerElapsedEvent(TimerElapsedEventHandler onTimerElapsed);
    }
}
