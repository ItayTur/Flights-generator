using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    /// <summary>
    /// Repository interface class that provides various database queries
    /// and CRUD operations.</summary>
    public interface IPlainsRepository
    {
        /// <summary>
        /// Gets the PlainModel entity associated with the specified ID.
        /// </summary>
        /// <param name="plainId">The unique plain ID.</param>
        /// <returns></returns>
        PlainModel GetPlain(int plainId);


        /// <summary>
        /// Gets all the PlainModel entities.
        /// </summary>
        /// <returns>Enumerator collection of all the PlainModel entites.</returns>
        IEnumerable<PlainModel> GetAll();


        /// <summary>
        /// Adds PlainModel entity based on the spcified PlainModel instance.
        /// </summary>
        /// <param name="plain">The PlainModel instance being added.</param>
        void Add(PlainModel plain);


        /// <summary>
        /// Removes the plain entity associated with the specified ID.
        /// </summary>
        /// <param name="plainId">The unique plain ID.</param>
        void Remove(int plainId);


        /// <summary>
        /// Updates the plain entity associated with the given PlainModel. 
        /// </summary>
        /// <param name="plain">The updated plain holding the unique plain ID.</param>
        void Update(PlainModel plain);
    }
}
