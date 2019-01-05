using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface for the client caller.
    /// </summary>
    public interface IHubHelper
    {
        /// <summary>
        /// Notify the client that a flight is about to start.
        /// </summary>
        /// <param name="flight">The FlightModel instance that about to enter base station.</param>
        void FlightAdded(FlightModel flight);
    }
}
