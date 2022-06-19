using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models.Dtos
{
    public class SearchResultDto
    {
        public Flight Flight { get; set; }
        public List<FlightLeg> FlightLegs { get; set; }

    }
}
