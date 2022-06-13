using IdenTicket.Enums;
using System.Collections.Generic;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Рейса
    /// </summary>
    public class Flight
    {
        public int Id { get; set; }
        public FlightType FlightType { get; set; }

        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
