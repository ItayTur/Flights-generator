using Common.Args;
using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;

namespace BL.Managers.StationsManager
{
    /// <summary>
    /// Handles the flights entering the base stations.
    /// </summary>
    public class StationWatingsManager : IWaitingStationsManager
    {

        #region Private fields

        private event FlightEventHandler FlightEnterEvent;
        private readonly object lockObj = new object();
        private List<StationModel> baseDepartureStations;
        private List<StationModel> baseLandStations;
        private List<FlightModel> LandingFlights;
        private List<FlightModel> DepartureFlights;
        private readonly IStationsRepository stationsRepository;
        private IEnumerable<StationModel> stations;

        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stationsRepository"></param>
        public StationWatingsManager(IStationsRepository stationsRepository)
        {
            baseLandStations = new List<StationModel>();
            baseDepartureStations = new List<StationModel>();

            LandingFlights = new List<FlightModel>();
            DepartureFlights = new List<FlightModel>();
            this.stationsRepository = stationsRepository;
            GenerateStations(stationsRepository);
        }


        /// <summary>
        /// Constructor helper initialize the stations list.
        /// </summary>
        /// <param name="stationsRepository"></param>
        private void GenerateStations(IStationsRepository stationsRepository)
        {
            stations = stationsRepository.GetAll();
            foreach (StationModel station in stations)
            {
                station.RegisterFlightEvent(OnFlightEvent);
                if (station.IsDepartureStart)
                {
                    baseDepartureStations.Add(station);
                }
                if (station.IsLandingStart)
                {
                    baseLandStations.Add(station);
                }
            }
        }



        /// <summary>
        /// Addes a flight to the waiting list of one of the base stations.
        /// </summary>
        /// <param name="flight">The FlightModel instance to be inserted the waiting list</param>
        public void AddNewFlight(FlightModel flight)
        {
            if (flight.IsDeparture)
                DepartureFlights.Add(flight);
            else
                LandingFlights.Add(flight);
            MoveToBase(flight);
        }



        /// <summary>
        /// Send an entring flight to the most suiteted station.
        /// </summary>
        /// <param name="flight"></param>
        private void MoveToBase(FlightModel flight)
        {
            MokeStation newMoke;
            StationModel nextStation;
            if (flight.IsDeparture)
            {
                newMoke = new MokeStation(DepartureFlights, flight);
                nextStation = GetShorterWatingListStation(baseDepartureStations);
            }
            else
            {
                newMoke = new MokeStation(LandingFlights, flight);
                nextStation = GetShorterWatingListStation(baseLandStations);
            }
            nextStation.AddStation(newMoke);
        }



        /// <summary>
        /// Get the station model with the shortest waiting list. 
        /// </summary>
        /// <param name="stationList">The list from which the base station is picked</param>
        /// <returns></returns>
        private StationModel GetShorterWatingListStation(List<StationModel> stationList)
        {

            StationModel stationToReturn = null;
            int min = int.MaxValue;
            foreach (var station in stationList)
            {
                if (station.WaitingStationsList.Count < min)
                {
                    stationToReturn = station;
                    min = station.WaitingStationsList.Count;
                }
            }
            return stationToReturn;


        }



        /// <summary>
        /// Register a function to be called when the flight event occured.
        /// </summary>
        /// /// <param name="onFlightStart">The FlightEventHandler function registering the flight event.</param>
        public void RegisterToFlightEvent(FlightEventHandler onFlightEvent)
        {
            FlightEnterEvent += onFlightEvent;
        }


        /// <summary>
        /// The function being called when the flight event occured.
        /// </summary>
        /// <param name="args">The arguments being processed by the event subscribers.</param>
        private void OnFlightEvent(FlightMoveArgs args)
        {
            if (args.StationId != null)
            {
                StationModel station = stationsRepository.Get((int)args.StationId);
                station.FlightId = args.Flight.ID;
                stationsRepository.Update(station);
            }
            if (args.OldStation != null && args.OldStation.Id != 0)
            {
                StationModel oldStation = stationsRepository.Get(args.OldStation.Id);
                oldStation.FlightId = null;
                stationsRepository.Update(oldStation);
            }

            FlightEnterEvent.Invoke(args);
        }

    }
}
