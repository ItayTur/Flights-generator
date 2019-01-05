using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Args
{
    /// <summary>
    /// Arguments passing when flight move event occured.
    /// </summary>
    public class FlightMoveArgs : EventArgs
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="flight">The FlightModel instance that moving.</param>
        /// <param name="stationId">The ID of the station the flight move to.</param>
        /// <param name="oldStation">The StationModel instatnce the flight moved from.</param>
        public FlightMoveArgs(FlightModel flight, int? stationId, IStationModel oldStation = null)
        {
            Flight = flight;

            StationId = stationId;

            OldStation = oldStation;
        }

        public FlightModel Flight { get; }

        public int? StationId { get; }

        public IStationModel OldStation { get; }
    }
}
