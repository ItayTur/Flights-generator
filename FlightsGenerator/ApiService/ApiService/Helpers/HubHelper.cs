using ApiService.Hubs;
using Common.Args;
using Common.Dtos;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace ApiService.Helpers
{
    /// <summary>
    /// Helping extract calls from the server to the client.
    /// </summary>
    public class HubHelper :IHubHelper
    {

        /// <summary>
        ///Constructor.
        /// </summary>
        /// <param name="flightsManager">The manager holding the flight event to be registered. </param>
        public HubHelper(IFlightsManager flightsManager)
        {
            flightsManager.RegisterToFlightStartEvent(OnFlightMove);
        }



        /// <summary>
        /// Notifing the clients that the flight event occured.
        /// </summary> 
        /// <param name="args">The arrguments processed and send to the client about the event.</param>
        private void OnFlightMove(FlightMoveArgs args)
        {
            IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<FlightsHub>();
            FlightDto flightDto = GetFlightDto(args);
            _hub.Clients.All.FlightMove(flightDto);
        }




        /// <summary>
        /// Convert the event arguments to passable object. 
        /// </summary>
        private FlightDto GetFlightDto(FlightMoveArgs args)
        {
            var flight = args.Flight;
            PlainDto plainDto = new PlainDto
            {
                Id = flight.Plain.Id,
                Sits = flight.Plain.Sits,
                Name = flight.Plain.Name
            };
            FlightDto flightDto = new FlightDto
            {
                ID = flight.ID,
                StationId = args.StationId,
                IsDeparture = flight.IsDeparture,
                IsFinish = flight.IsFinish,
                FlightName = flight.FlightName,
                Time = flight.Time,
            };

            return flightDto;
        }




        /// <summary>
        /// Notify the client that a flight is about to start.
        /// </summary>
        /// <param name="flight">The FlightModel instance that about to enter base station.</param>
        public void FlightAdded(FlightModel flight)
        {
            IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<FlightsHub>();
            var flightDto = flight.ConvertToFlightDto();
            _hub.Clients.All.FlightMove(flightDto);
        }
    }
}