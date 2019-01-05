using Common.Interfaces;
using Common.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SqlRepositories
{
    /// <summary>
    /// Repository class that provides various database queries
    /// and CRUD operations.
    /// </summary>
    public class SqlStationsRepository : IStationsRepository
    {
        /// <summary>
        /// Adds a station.
        /// </summary>
        /// <param name="station">The StationModel entity instance to add.</param>
        public void Add(StationModel station)
        {
            using (Context context = new Context())
            {
                context.Stations.Add(station);
                context.SaveChanges();
            }
        }

        
        /// <summary>
        /// Gets the station associated with the spcified ID.
        /// </summary>
        /// <param name="stationId">The station ID to retrieve.</param>
        /// <returns>A fully populated StationModel entity instance.</returns>
        public StationModel Get(int stationId)
        {
            using (Context context = new Context())
            {
                return context.Stations.FirstOrDefault(s => s.Id == stationId);
            }
        }



        /// <summary>
        /// Gets all of the stations.
        /// </summary>
        /// <returns>A list of StationModel entity instances including their next in line stations .</returns>
        public IEnumerable<StationModel> GetAll()
        {
            using (Context context = new Context())
            {
                return context.Stations.Include(s => s.NextDepartureStations).Include(s => s.NextLandingStations).ToList();
            }
        }



        /// <summary>
        /// Removes the station associated with the spcified ID.
        /// </summary>
        /// <param name="stationId">The station ID to remove.</param>
        public void Remove(int stationId)
        {
            using (Context context = new Context())
            {
                var station = context.Stations.Find(stationId);
                context.Stations.Add(station);
                context.SaveChanges();
            }
        }



        /// <summary>
        /// Update the station associated with specified StationModel instance.
        /// </summary>
        /// <param name="station">The StationtModel entity instance to update.</param>
        public void Update(StationModel station)
        {
            using (Context context = new Context())
            {
                context.Stations.Attach(station);
                context.Entry(station).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
