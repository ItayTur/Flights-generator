using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    /// <summary>
    /// Class for create passable PlainModel data in the web api.
    /// </summary>
    public class PlainDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sits { get; set; }
        public List<FlightModel> Flights { get; set; }

        public PlainDto()
        {
            Flights = new List<FlightModel>();
        }

        internal PlainModel ConvertToPlainModel()
        {
            PlainModel plain = new PlainModel();
            plain.Flights = Flights;
            plain.Id = Id;
            plain.Name = Name;
            plain.Sits = Sits;
            return plain;
        }
    }
}
