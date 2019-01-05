using Common.Args;
using Common.Enums;
using Common.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    /// <summary>
    /// Delegate for passing the flight event args to the subscribers.
    /// </summary>
    /// <param name="args"></param>
    public delegate void FlightEventHandler(FlightMoveArgs args);

    public class StationModel : IStationModel
    {
        #region Properties
        private event FlightEventHandler _flightEvent;

        public int? FlightId { get; set; }

        public FlightModel Flight { get; set; }

        public int Id { get; set; }

        public bool IsDepartureStart { get; set; }

        public bool IsDepartureEnd { get; set; }

        public bool IsLandingStart { get; set; }

        public bool IsLandingEnd { get; set; }

        public StripEnum Strip { get; set; }

        public bool IsOccupied { get; set; }

        public List<StationModel> NextDepartureStations { get; set; }
        public List<StationModel> NextLandingStations { get; set; }

        public List<IStationModel> WaitingStationsList { get; set; }

        #endregion



        /// <summary>
        /// Constructor.
        /// </summary>
        public StationModel()
        {
            NextDepartureStations = new List<StationModel>();
            NextLandingStations = new List<StationModel>();
            WaitingStationsList = new List<IStationModel>();
        }



        /// <summary>
        /// Adds station to the NextDepartureStations list.
        /// </summary>
        /// <param name="station">The station instance being added.</param>
        public void AddDepartureStation(StationModel station)
        {
            NextDepartureStations.Add(station);
        }



        /// <summary>
        /// Adds station to the NextLandingStations list.
        /// </summary>
        /// <param name="station">The station instance being added.</param>
        public void AddLandingStation(StationModel station)
        {
            NextLandingStations.Add(station);
        }



        /// <summary>
        /// Enter the waiting list of the next station in line.
        /// if its the last station it's just evacuate the station.
        /// </summary>
        private void OperationTimeEnded()
        {
            if ((Flight.IsDeparture && IsDepartureEnd) || (!Flight.IsDeparture && IsLandingEnd))
            {
                Flight.IsFinish = true;
                OnFlightEnd();
                EvacuateStation();
            }
            else
            {
                StationModel nextStation;
                if (Flight.IsDeparture)
                {
                    nextStation = GetBestStation(NextDepartureStations);
                }
                else
                {
                    nextStation = GetBestStation(NextLandingStations);
                }
                nextStation.AddStation(this);
            }
        }


        /// <summary>
        /// Find the station with the shortes waiting list.
        /// </summary>
        /// <param name="nextStations">The collection of which the search is made on.</param>
        /// <returns></returns>
        private StationModel GetBestStation(ICollection<StationModel> nextStations)
        {
            int min = int.MaxValue;
            StationModel stationToReturn = null;
            foreach (StationModel station in nextStations)
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
        /// Empty the fields of the station, and call the next station in line.
        /// </summary>
        public void EvacuateStation()
        {
            Flight = null;
            FlightId = null;
            if (WaitingStationsList.Count > 0)
                CallNextFlight();
        }



        /// <summary>
        /// Addes a station the the waiting list.
        /// </summary>
        /// <param name="station"> Instatnce of the IStationModel entering the waiting list.</param>
        public void AddStation(IStationModel station)
        {
            WaitingStationsList.Add(station);
            if (Flight == null)
                CallNextFlight();
        }



        /// <summary>
        /// Register a function to be called when FlightEvent rise.
        /// </summary>
        /// <param name="flightEvent">The FlightEventHandler function to be called on the event.</param>
        public void RegisterFlightEvent(FlightEventHandler flightEvent)
        {
            _flightEvent += flightEvent;
        }


        /// <summary>
        /// Fill the fields with the data from the next station in the waiting list.
        /// Invoke the flight event.
        /// </summary>
        private void CallNextFlight()
        {
            if (WaitingStationsList.Count > 0)
            {
                var nextWaitingStation = WaitingStationsList[0];
                Flight = nextWaitingStation.Flight;
                FlightId = nextWaitingStation.FlightId;
                OnFlightEnteredEvent(nextWaitingStation);
                nextWaitingStation.EvacuateStation();
                Flight.StartOperation().ConfigureAwait(false).GetAwaiter().GetResult();
                WaitingStationsList.Remove(nextWaitingStation);
                OperationTimeEnded();
            }
        }

        /// <summary>
        /// Invoking the FlightEvent.
        /// </summary>
        /// <param name="oldStation">IStationModel instance to be passed to the handler subscribers.</param>
        private void OnFlightEnteredEvent(IStationModel oldStation)
        {

            FlightMoveArgs args = new FlightMoveArgs(Flight, Id, oldStation);
            _flightEvent?.Invoke(args);
        }



        /// <summary>
        /// Occures when the flight reach the last station in it's line.
        /// </summary>
        private void OnFlightEnd()
        {
            FlightMoveArgs args = new FlightMoveArgs(Flight, null);
            _flightEvent?.Invoke(args);
        }
    }


}
