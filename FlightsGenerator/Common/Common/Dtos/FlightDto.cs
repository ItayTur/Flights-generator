using Common.Models;
using System;

namespace Common.Dtos
{
    /// <summary>
    /// Class for create passable FlightModel data in the web api.
    /// </summary>
    public class FlightDto
    {
        public int ID { get; set; }

        public int? StationId { get; set; }

        public bool IsDeparture { get; set; }

        public bool IsFinish { get; set; }

        public string FlightName { get; set; }

        public DateTime Time { get; set; }

        public FlightModel ConvertToFlightModel()
        {
            FlightModel flight = new FlightModel();
            flight.FlightName = FlightName;
            flight.ID = ID;
            flight.IsDeparture = IsDeparture;
            flight.IsFinish = IsFinish;
            flight.Time = Time;
            return flight;
        }
    }
}
