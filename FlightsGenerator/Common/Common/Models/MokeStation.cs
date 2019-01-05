using Common.Interfaces;
using System.Collections.Generic;

namespace Common.Models
{
    /// <summary>
    /// Created when flight enter a station this is the the station its supposly came from
    /// </summary>
    public class MokeStation : IStationModel
    {
        #region Private fields

        private List<FlightModel> Flights { get; set; }

        #endregion


        #region Properties

        public int? FlightId { get; set; }

        public FlightModel Flight { get; set; }

        public int Id { get; set; }

        #endregion


        /// <summary>
        /// Constructor.
        /// </summary>
        public MokeStation(List<FlightModel> flights, FlightModel flight)
        {
            Flights = flights;
            Flight = flight;
            FlightId = flight.ID;
        }

        
        /// <summary>
        /// Remove the flight from the station when it moves to anther station.
        /// </summary>
        public void EvacuateStation()
        {
            Flights.Remove(Flight);
            FlightId = null;
            Flight = null;
        }




    }
}
