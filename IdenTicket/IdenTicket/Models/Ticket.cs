using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int CustomerId { get; set; }
        public int ClassType { get; set; }

    }
}
