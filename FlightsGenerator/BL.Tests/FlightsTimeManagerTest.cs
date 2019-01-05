using System;
using System.Threading;
using BL.Managers.FlightsManagers;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.Tests
{
    [TestClass]
    public class FlightsTimeManagerTest
    {
        FlightsTimeManager flightsTimeManager;
        [TestInitialize]
        public void Initialize()
        {
            flightsTimeManager = new FlightsTimeManager();
        }
        [TestMethod]
        public void Add_AddFirstFlight_FlightsListCountIsOneAndTimerIntervalEqualToFlightTimeEntered()
        {
            int seconds = 5;
            FlightModel flight = GetFlight(seconds);
            int newCount = 1;

            flightsTimeManager.Add(flight);
            int countResult = flightsTimeManager.GetFlightsCount();
            var intervalResult = flightsTimeManager.GetInterval();

            
            Assert.AreEqual(newCount, countResult);
            Assert.AreEqual(intervalResult, seconds);
        }

        private FlightModel GetFlight(int seconds, int id=1)
        {
            return new FlightModel() {ID=id, Time = DateTime.Now + new TimeSpan(0, 0, seconds) };
        }

        [TestMethod]
        public void Add_AddSecondFlightWithEarlierTimeThenFirst_FirstIdEqualToSecondFlightAddedId()
        {
            int firstId = 1;
            int firstSeconds = 10;
            int secondId = 2;
            int secondSeconds = 1;
            var firstFlight = GetFlight(firstSeconds, firstId);
            var secondFlight = GetFlight(secondSeconds, secondId);

            flightsTimeManager.Add(firstFlight);
            var firstIdBeforSecondAdd = flightsTimeManager.GetFirstId();
            flightsTimeManager.Add(secondFlight);
            var firstIdAfterSecondAdd = flightsTimeManager.GetFirstId();

            Assert.AreEqual(secondId, firstIdAfterSecondAdd);
            Assert.AreEqual(firstId, firstIdBeforSecondAdd);
        }

        [TestMethod]
        public void Add_AddLaterFlightThanFirst_InteralEqualToIntervalBeforAdd()
        {
            int firstId =1;
            int firstSeconds = 5;
            int secondId = 2;
            int secondSeconds = 10;
            FlightModel firstFlight = GetFlight(firstSeconds, firstId);
            FlightModel secondFlight = GetFlight(secondSeconds, secondId);

            flightsTimeManager.Add(firstFlight);
            var intervalBeforAdd = flightsTimeManager.GetInterval();
            var firstIdBefor = flightsTimeManager.GetFirstId();
            flightsTimeManager.Add(secondFlight);
            var firstIdAfter = flightsTimeManager.GetFirstId();
            var intervalAfterAdd = flightsTimeManager.GetInterval();

            Assert.AreEqual(intervalAfterAdd, intervalBeforAdd);
            Assert.AreEqual(firstIdBefor, firstIdAfter);
        }

        [TestMethod]
        public void Add_AddMultipleFlights_ItrationsCountEqualToReusltFlightsCount()
        {
            int itrations = 1000;
            int expectedCount = itrations * 2;
            Thread thread1 = new Thread(new ThreadStart(delegate () 
            {
                for (int i = 0; i < itrations; i++)
                {
                    var flight = GetFlight(1, i);
                    flightsTimeManager.Add(flight);
                }
            }));

            Thread thread2 = new Thread(new ThreadStart(delegate ()
            {
                for (int i = 0; i < itrations; i++)
                {
                    var flight = GetFlight(1, i);
                    flightsTimeManager.Add(flight);
                }
            }));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            var resultCount = flightsTimeManager.GetFlightsCount();

            Assert.AreEqual(expectedCount, resultCount);
        }
    }
}
