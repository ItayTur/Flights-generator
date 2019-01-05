using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;

namespace Common.Dtos
{
    /// <summary>
    /// Class for creating passable StationModel data in the web api.
    /// </summary>
    public class StationDto
    {
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

        public StationModel ConvertToStationModel()
        {
            StationModel station = new StationModel();
            station.Flight = Flight;
            station.FlightId = FlightId;
            station.Id = Id;
            station.IsDepartureEnd = IsDepartureEnd;
            station.IsDepartureStart = IsDepartureStart;
            station.IsLandingEnd = IsLandingEnd;
            station.IsLandingStart = IsLandingStart;
            station.IsOccupied = IsOccupied;
            station.NextDepartureStations = NextDepartureStations;
            station.NextLandingStations = NextLandingStations;
            station.Strip = Strip;
            station.WaitingStationsList = WaitingStationsList;
            return station;
        }
    }
}
