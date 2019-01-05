using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Repository interface class that provides various database queries
    /// and CRUD operations.</summary>
    public interface IStationsRepository
    {

        /// <summary>
        /// Returns an enomrator collection of stations.
        /// </summary>
        /// <returns>An enomrator collection of StationModel entity instances including their next in line stations .</returns>
        IEnumerable<StationModel> GetAll();


        /// <summary>
        /// Adds a station.
        /// </summary>
        /// <param name="station">The StationModel entity instance to add.</param>
        void Add(StationModel station);


        /// <summary>
        /// Removes the station entity associated with the spacified ID.
        /// </summary>
        /// <param name="stationId">The unique station ID.</param>
        void Remove(int stationId);


        /// <summary>
        /// Update the station entity associated with the spcified StationModel instance.
        /// </summary>
        /// <param name="station">The StationtModel entity instance to update.</param>
        void Update(StationModel station);


        /// <summary>
        /// Gets the station entity associated with the spcified ID.
        /// </summary>
        /// <param name="stationId">The unique station ID.</param>
        /// <returns>A fully populated StationModel instance.</returns>
        StationModel Get(int stationId);
    }
}
