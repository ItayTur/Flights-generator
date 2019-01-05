using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Args
{
    /// <summary>
    /// Arguments for when flight enter base station.
    /// </summary>
    public class FlightEventArgs : EventArgs
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="flight"></param>
        public FlightEventArgs(FlightModel flight)
        {
            Flight = flight;
        }

        public FlightModel Flight { get; }
    }
}
