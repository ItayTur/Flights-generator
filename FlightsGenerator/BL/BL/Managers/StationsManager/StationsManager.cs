using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.StationsManager
{
    /// <summary>
    /// Manager handling the flight that needs to be enterd first station.
    /// And the corresponding events.
    /// </summary>
    public class StationsManager: IStationsManager
    {
        #region Private fields

        private readonly IWaitingStationsManager _stationsWaitingsManager;
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public StationsManager( IWaitingStationsManager stationsWaitingsManager)
        {
            _stationsWaitingsManager = stationsWaitingsManager;
        }

        
        /// <summary>
        /// The function beind called when timer elpased occured.
        /// </summary>
        /// <param name="flight">The FlightModel instance needs to be enter the base station.</param>
        public void FlightTimeArrivedEvent(FlightModel flight)
        {
            _stationsWaitingsManager.AddNewFlight(flight);
        }



        /// <summary>
        /// Register a function to be called when the flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        public void RegisterToFlightStartEvent(FlightEventHandler flightEnterEvent)
        {
            _stationsWaitingsManager.RegisterToFlightEvent(flightEnterEvent); ;
        }
    }
}
