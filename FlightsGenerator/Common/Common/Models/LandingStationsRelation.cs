using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    /// <summary>
    /// The entity holding the landing connection between the verious stations.
    /// </summary>
    public class LandingStationsRelation
    {
        [Key, Column(Order = 0)]
        public int StationId { get; set; }

        [Key, Column(Order = 1)]
        public int NextStationId { get; set; }

        [ForeignKey("StationId")]
        public StationModel Station { get; set; }

        [ForeignKey("NextStationId")]
        public StationModel NextStation { get; set; }
    }
}
