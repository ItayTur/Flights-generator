using Common.Args;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface containing all the fuctions and data
    /// that needs to be transferd by the stations.
    /// </summary>
    public interface IStationModel
    {


        /// <summary>
        /// Evacuate the station from the flight it was containing.
        /// </summary>
        void EvacuateStation();


        /// <summary>
        /// The flight id associated with the flight being contained by the station.
        /// </summary>
        int? FlightId { get; set; }


        /// <summary>
        /// The FligthModel instatnce contatined by the station.
        /// </summary>
        FlightModel Flight { get; set; }


        /// <summary>
        /// The station ID.
        /// </summary>
         int Id { get; set; }
    }
}
