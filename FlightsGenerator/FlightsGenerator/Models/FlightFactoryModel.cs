using Common.Models;
using FlightsGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsGenerator.Models
{
    /// <summary>
    /// Creates new FlightModel instance.
    /// </summary>
    public class FlightFactoryModel: IFlightFactory
    {
        #region Private fields

        private Random rnd = new Random();
        private int id = 1;

        #endregion


        /// <summary>
        /// Create a flight model.
        /// </summary>
        /// <returns> new FlightModel instance</returns>
        public FlightModel CreateFlight()
        {
            string flightName = id.ToString();
            id++;
            PlainModel plain = GetNewPlain();
            bool isDeparture = GetIsDeparture();
            DateTime planedTime = GetPlanedTime();
            return new FlightModel()
            {
                FlightName = flightName,
                IsDeparture = isDeparture,
                Plain = plain,
                Time = planedTime
            };
        }


        /// <summary>
        /// Create a plain.
        /// </summary>
        /// <returns>new PlainModel instance.</returns>
        private PlainModel GetNewPlain()
        {
            char firstLatter = (char)rnd.Next(65, 90);
            char secondLatter = (char)rnd.Next(65, 90);
            string number = rnd.Next(100, 999).ToString();
            PlainModel newPlain = new PlainModel()
            {
                Name = firstLatter + secondLatter + number,
                Sits = rnd.Next(150, 1000)
            };
            return newPlain;
        }


        /// <summary>
        /// Return new date time.
        /// </summary>
        private DateTime GetPlanedTime()
        {
            TimeSpan timeSpan = new TimeSpan(0,0, rnd.Next(10, 15));
            return DateTime.Now + timeSpan;
        }


        /// <summary>
        /// Return a random bool.
        /// </summary>
        /// <returns></returns>
        private bool GetIsDeparture()
        {
            int way = rnd.Next(0, 2);
            if (way == 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Return a random name.
        /// </summary>
        private string GetName()
        {
            char firstLatter = (char)rnd.Next(65, 90);
            char secondLatter = (char)rnd.Next(65, 90);
            string number = rnd.Next(100, 999).ToString();
            return firstLatter + secondLatter + number;
        }
    }
}
