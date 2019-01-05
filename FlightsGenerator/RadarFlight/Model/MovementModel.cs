using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarFlight.Model
{
    class MovementModel
    {
        public int? StationId { get; set; }
        public FlightModel Flight { get; set; }
    }
}
