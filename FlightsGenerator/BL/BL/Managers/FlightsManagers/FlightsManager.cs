using Common.Args;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.FlightsManagers
{
    /// <summary>
    /// Direct flight to the manager they need in any given time.
    /// invoke events the client should be notified about.
    /// </summary>
    public class FlightsManager : IFlightsManager
    {
        #region Private Fields

        private readonly IFlightsRepository _flightsRepository;

        private readonly IStationsRepository _stationsRepository;

        private readonly IFlightsTimeManager _flightsTimeManager;

        private readonly IStationsManager _stationsManager;

        private event FlightEventHandler _flightStartEvent;

        #endregion



        /// <summary>
        /// FlightsManager constructor.
        /// </summary>
        public FlightsManager(IFlightsTimeManager flightsTimeManager, IFlightsRepository flightsRepository, IStationsManager stationsManager, IStationsRepository stationsRepository)
        {
            _flightsRepository = flightsRepository;
            _flightsTimeManager = flightsTimeManager;
            _flightsTimeManager.RegisterToTimerElapsedEvent(OnTimerEvent);
            _stationsManager = stationsManager;
            _stationsRepository = stationsRepository;

            _stationsManager.RegisterToFlightStartEvent(OnFlightEnterEvent);
        }



        /// <summary>
        /// Returns an enomrator collection of flights.
        /// </summary>
        /// <returns>An enomrator collection of FlightModel instances.</returns>
        public IEnumerable<FlightModel> GetAll()
        {
            return _flightsRepository.GetAll();
        }



        /// <summary>
        /// Called when flight event occured.
        /// </summary>
        /// <param name="args">The handler arguments to be processed .</param>
        private void OnFlightEnterEvent(FlightMoveArgs args)
        {
            UpdateFlightsManager(args);
            NotifyFlightStart(args);
        }



        /// <summary>
        /// If the flight move to base update the FlightTimeManager 
        /// </summary>
        private void UpdateFlightsManager(FlightMoveArgs args)
        {
            if ((args.OldStation!=null)&&(args.OldStation.Id==0))
                _flightsTimeManager.EnterBaseStation();
        }



        /// <summary>
        /// Notify subscribers on flight event
        /// </summary>
        private void NotifyFlightStart(FlightMoveArgs args)
        {
            _flightStartEvent.Invoke(args);
        }



        /// <summary>
        /// Adds a flight to the database and the time manager queue.
        /// </summary>
        /// <param name="flight">The FlightModel instance to add the database and the time manager queue.</param>
        /// <returns>The FlightModel entity instance after being processed by the Repository</returns>
        public FlightModel AddFlight(FlightModel flight)
        {
            flight = _flightsRepository.Add(flight);
            _flightsTimeManager.Add(flight);

            return flight;
        }



        /// <summary>
        /// Called when timer elapsed event occurred in the time manager.
        /// </summary>
        /// <param name="flight">The FlightModel instance ready to enter base station.</param>
        private void OnTimerEvent(FlightModel flight)
        {
            _stationsManager.FlightTimeArrivedEvent(flight);
        }



        /// <summary>
        /// Register a function to be called when flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        public void RegisterToFlightStartEvent(FlightEventHandler onFlightStart)
        {
            _flightStartEvent += onFlightStart;
        }


        /// <summary>
        /// Returns an enomrator collection of stations.
        /// </summary>
        /// <returns>An enomrator collection of StationModel entity instances including their next in line stations .</returns>
        public IEnumerable<StationModel> GetStations()
        {
            return _stationsRepository.GetAll();
        }
    }
}
