using Common.Models;
using FlightsGenerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlightsGenerator
{
    /// <summary>
    /// Application for creating flights.
    /// </summary>
    class Program
    {
        #region Private fields

        private const string apiUrl = "http://localhost:53028/api/Flights";
        private static readonly HttpClient client = new HttpClient();
        private static FlightFactoryModel factoryFlight;
        private static Timer timer;

        #endregion


        /// <summary>
        /// Initialize the FlightFactoryModel and the timer and start it.
        /// </summary>
        static void Main(string[] args)
        {
            
            factoryFlight = new FlightFactoryModel();
            timer = new Timer
            {
                Interval = 10000
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.Read();
        }



        /// <summary>
        /// Event rise when the timer elapsed.
        /// </summary>
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendNewFlight();
            
        }



        /// <summary>
        /// Create new flight and send it to the web api service.
        /// </summary>
        private static void SendNewFlight()
        {
            FlightModel newFlight = factoryFlight.CreateFlight();
            Console.WriteLine(newFlight.ToString());
            var jsonObject = JsonConvert.SerializeObject(newFlight);
            var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
            client.PostAsync(apiUrl, stringContent);
        }
    }
}
