using BL.Managers.FlightsManagers;
using Common.Args;
using Common.Interfaces;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Tests
{
    [TestClass]
    public class FlightsManagerTest
    {
        private Mock<IFlightsTimeManager> flightsTimeManagerMock;
        private Mock<IFlightsRepository> flightsRepositoryMock;
        private Mock<IStationsManager> stationsManagerMock;
        private Mock<IWaitingStationsManager> waitingStationsManagerMock;
        private Mock<IStationsRepository> stationsRepositoryMock;
        private FlightsManager flightsManager;

        [TestInitialize]
        public void Initialize()
        {
            flightsTimeManagerMock = new Mock<IFlightsTimeManager>();
            flightsRepositoryMock = new Mock<IFlightsRepository>();
            stationsManagerMock = new Mock<IStationsManager>();
            waitingStationsManagerMock = new Mock<IWaitingStationsManager>();
            stationsRepositoryMock = new Mock<IStationsRepository>();
            flightsManager = new FlightsManager(flightsTimeManagerMock.Object, flightsRepositoryMock.Object, stationsManagerMock.Object, stationsRepositoryMock.Object);
        }

        [TestMethod]
        public void GetAll_ReturnAllTheFlightsInTheDb()
        {
            //Arrange
            int validFlightsCount = 5;
            IEnumerable<FlightModel> flights = GetFakeFlights(validFlightsCount);
            flightsRepositoryMock.Setup(x => x.GetAll()).Returns(flights);
            //Act
            var resultFlights = flightsManager.GetAll();
            //Assert
            Assert.AreEqual(validFlightsCount, resultFlights.Count());
        }
        private IEnumerable<FlightModel> GetFakeFlights(int flightsCount)
        {
            ICollection<FlightModel> flights = new List<FlightModel>();
            for (int i = 0; i < flightsCount; i++)
            {
                flights.Add(new FlightModel() { ID = i });
            }

            return flights;
        }
        [TestMethod]
        public void AddFlight_ReturnFlightModelWithDiffrentIdAndSameName()
        {
            //Assert
            FlightModel flightToAdd = new FlightModel() { ID = 0, FlightName = "flightToAdd" };
            FlightModel flightToReturn = new FlightModel() { ID = 1, FlightName = "flightToAdd" };
            flightsRepositoryMock.Setup(x => x.Add(flightToAdd)).Returns(flightToReturn);

            //Act
            var resultFlight = flightsManager.AddFlight(flightToAdd);

            //Assert
            Assert.AreNotEqual(flightToAdd.ID, resultFlight.ID);
            Assert.AreEqual(flightToAdd.FlightName, resultFlight.FlightName);
        }

        [TestMethod]
        public void RegisterToFlightStartEvent_NotThrowsAnException()
        {
            flightsManager.RegisterToFlightStartEvent(GetFlightHandlerMock);
        }

        private void GetFlightHandlerMock(FlightMoveArgs args)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetStations_StationsCountIsEqualToInsertedStationsCount()
        {
            int stationsCount = 5;
            var stations = GetFakeStations(stationsCount);
            stationsRepositoryMock.Setup(x => x.GetAll()).Returns(stations);

            var resultStations = flightsManager.GetStations();

            Assert.AreEqual(stationsCount, resultStations.Count());
        }

        private IEnumerable<StationModel> GetFakeStations(int stationsCount)
        {
            ICollection<StationModel> stations = new List<StationModel>();
            for (int i = 0; i < stationsCount; i++)
            {
                stations.Add(new StationModel { Id = i });
            }

            return stations;
        }
    }
}
