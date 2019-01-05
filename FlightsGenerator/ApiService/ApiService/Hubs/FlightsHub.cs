using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiService.Hubs
{
    /// <summary>
    /// Sending all the calls maid by the server to the clients.
    /// </summary>
    [HubName("FlightsHub")]
    public class FlightsHub : Hub
    {
        
    }
}