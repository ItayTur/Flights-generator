using ApiService.Helpers;
using ApiService.Hubs;
using Common.Args;
using Common.Dtos;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiService.Controllers
{
    /// <summary>
    /// Controller holding the flights manager for http responses,
    /// and the hub helper for server calls. </summary>
    public class FlightsController : ApiController
    {
        #region Private fields

        private readonly IFlightsManager _flightsManager;

        private readonly IHubHelper _hubHelper;

        #endregion


        /// <summary>
        /// Constructor.
        /// </summary>
        public FlightsController(IFlightsManager flightsManager, IHubHelper hubHelper)
        {
            _flightsManager = flightsManager;
            _hubHelper = hubHelper;
        }

        

        /// <summary>
        /// Convert the stations list into StationDto list.
        /// </summary>
        private IEnumerable<StationDto> GetStationDtos()
        {
            var modelStations = _flightsManager.GetStations();
            var dtoStations = from s in modelStations
                              select new StationDto()
                              {
                                  Id = s.Id,
                                  Flight = s.Flight,
                                  FlightId = s.FlightId,
                                  IsDepartureStart = s.IsDepartureStart,
                                  IsDepartureEnd = s.IsDepartureEnd,
                                  IsLandingStart = s.IsLandingStart,
                                  IsLandingEnd = s.IsLandingEnd,
                                  Strip = s.Strip,
                                  IsOccupied = s.IsOccupied,
                                  NextDepartureStations = s.NextDepartureStations,
                                  NextLandingStations = s.NextLandingStations,
                                  WaitingStationsList = s.WaitingStationsList
                              };
            return dtoStations;
        }


        /// <summary>
        /// Convert the FlightModel list int FlightDto list.
        /// </summary>
        /// <returns>Enomerator of FlightDto instances.</returns>
        private IEnumerable<FlightDto> GetFlightDtos()
        {
            var flights = _flightsManager.GetAll();
            var flightDtos = (from flight in flights
                             select flight.ConvertToFlightDto()).ToList();

            return flightDtos;
        }



        /// <summary>
        /// Returns a list of FlightDto instances.
        /// </summary>
        public IEnumerable<FlightDto> Get()
        {
            return GetFlightDtos();
        }


        /// <summary>
        /// Returns an enumerator of StationDto instances.
        /// </summary>
        [Route("api/Flights/Stations")]
        public IEnumerable<StationDto> GetStations()
        {
            return GetStationDtos();
        }


        /// <summary>
        /// Post a flight into the FlightsManager.
        /// </summary>
        /// <param name="flight">The FlightModel instance that being post by the client.</param>
        /// <returns>IHttpActionResult pointing whether the model is valid.</returns>
        [HttpPost]
        [ResponseType(typeof(FlightModel))]
        public IHttpActionResult AddFlight(FlightModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            flight = _flightsManager.AddFlight(flight);
            
            _hubHelper.FlightAdded(flight);
            return CreatedAtRoute("DefaultApi", new { id = flight.ID }, flight);
        }

        
    }
}
