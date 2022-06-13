using IdenTicket.Enums;
using IdenTicket.Interfaces;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Билета
    /// </summary>
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string CustomerId { get; set; }

        public ClassType ClassType { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
