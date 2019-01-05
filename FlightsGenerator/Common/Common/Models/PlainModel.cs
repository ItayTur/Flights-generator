using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dtos;

namespace Common.Models
{
    public class PlainModel
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public int Sits { get; set; }

        public ICollection<FlightModel> Flights { get; set; }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlainModel()
        {
            Flights = new List<FlightModel>();
        }


        /// <summary>
        /// Convert this instance into data trnasfer object.
        /// </summary>
        /// <returns> A fully populated PlainDto instance.</returns>
        internal PlainDto ConvertToPlainDto()
        {
            PlainDto plainDto = new PlainDto()
            {
                Id = Id,
                Name = Name,
                Sits = Sits,
                Flights = Flights.ToList()
            };

            return plainDto;
        }
    }
}
