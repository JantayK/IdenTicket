using IdenTicket.Enums;
using IdenTicket.Interfaces;
using System.Collections.Generic;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Рейса
    /// </summary>
    public class Flight : IEntity
    {
        public int Id { get; set; }
        public FlightType FlightType { get; set; }

        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
