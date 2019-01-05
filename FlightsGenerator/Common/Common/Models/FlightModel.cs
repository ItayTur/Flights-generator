using Common.Dtos;
using System;
using System.Threading.Tasks;

namespace Common.Models
{
    /// <summary>
    /// The flight entity.
    /// </summary>
    public class FlightModel : IComparable<FlightModel>
    {
        #region Properties

        public int ID { get; set; }

        public int PlainId { get; set; }

        public bool IsDeparture { get; set; }

        public bool IsFinish { get; set; }

        public string FlightName { get; set; }

        public DateTime Time { get; set; }


        public PlainModel Plain { get; set; }

        #endregion


        /// <summary>
        /// Compare between this FlightModel and the specified other FlightModel,
        /// based on their Time property.
        /// </summary>
        /// <param name="other">The FlightModel instance to be compared to.</param>
        /// <returns></returns>
        public int CompareTo(FlightModel other)
        {
            return DateTime.Compare(Time, other.Time);
        }


        /// <summary>
        /// Starting the oppration the flight needs to go throw in the station.
        /// </summary>
        internal async Task StartOperation()
        {
            Random random = new Random();
            await Task.Delay(random.Next(5000, 10000));
        }



        /// <summary>
        /// Stringfy all the flight data.
        /// </summary>
        /// <returns>The flight data in one string.</returns>
        public override string ToString()
        {
            return string.Format($"Name : {FlightName }  plain : {Plain.Name}  Date : {Time}  isDeparture : {IsDeparture}");
        }


        /// <summary>
        /// Convert the instance into data transfer objet.
        /// </summary>
        /// <returns>FlightDto instance associated with this FlightModel.</returns>
        public FlightDto ConvertToFlightDto()
        {
            FlightDto flightDto = new FlightDto();
            flightDto.ID = ID;
            flightDto.IsDeparture = IsDeparture;
            flightDto.IsFinish = IsFinish;
            flightDto.Time = Time;
            flightDto.FlightName = FlightName;
            return flightDto;
        }
    }
}
