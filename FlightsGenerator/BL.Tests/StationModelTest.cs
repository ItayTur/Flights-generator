using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.Tests
{
    [TestClass]
    public class StationModelTest
    {
        [TestMethod]
        public void AddStation_AddStationToEmptyStation_WaitingStationsCountIsZero()
        {
            int expectedCount = 0;
            bool isDepartureEnd1 = true;
            StationModel station = GetStation(1, isDepartureEnd1);
            FlightModel flight = GetFlight();
            bool isDepartureEnd2 = false;
            bool isDepartureStart = true;
            var stationToAdd = GetStation(2, isDepartureEnd2, isDepartureStart, flight);
            stationToAdd.NextDepartureStations.Add(station);

            int newCount = station.WaitingStationsList.Count;
            
            Assert.AreEqual(expectedCount, newCount);
        }

        private static StationModel GetStation(int id=1,bool isDepartureEnd=false,bool isDepartureStart = false,FlightModel flight=null )
        {
            return new StationModel() { Id = id, IsDepartureEnd = isDepartureEnd , IsDepartureStart=isDepartureStart};
        }

        private static FlightModel GetFlight()
        {
            return new FlightModel() { ID = 1, IsDeparture = true };
        }

        [TestMethod]
        public void AddDepartureStation_AddStationToEmptyStation_DeprartureStationCountIsOne()
        {
            var station = GetStation();
            var stationToAdd = GetStation(2);
            int expectedCount = 1;

            station.AddDepartureStation(stationToAdd);
            int resultCount = station.NextDepartureStations.Count;

            Assert.AreEqual(expectedCount, resultCount);

        }

        [TestMethod]
        public void AddLandingStation_AddStationToEmptyStation_LandingStationCountIsOne()
        {
            var station = GetStation();
            var stationToAdd = GetStation(2);
            int expectedCount = 1;

            station.AddLandingStation(stationToAdd);
            int resultCount = station.NextLandingStations.Count;

            Assert.AreEqual(expectedCount, resultCount);

        }
    }
}
