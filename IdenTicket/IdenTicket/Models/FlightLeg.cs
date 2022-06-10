using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    public class FlightLeg
    {
        public int FlightId { get; set; }
        public int AirLineId { get; set; }
        public int AirplaneModelId { get; set; }
        public int LegNumber { get; set; }
        public int Direction { get; set; }
        public int DepartAirportId { get; set; }
        public DateTime DepartDate { get; set; }
        public int ArriveAirportId { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
