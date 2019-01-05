using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsGenerator.Interfaces
{
    /// <summary>
    /// Creating flights.
    /// </summary>
    public interface IFlightFactory
    {

        /// <summary>
        /// Create FlightModel instance.
        /// </summary>
        /// <returns>The FlightModel instance created.</returns>
        FlightModel CreateFlight();
    }
}
