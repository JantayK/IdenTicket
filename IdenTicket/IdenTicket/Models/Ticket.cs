using IdenTicket.Enums;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Билета
    /// </summary>
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int CustomerId { get; set; }

        public ClassType ClassType { get; set; }
        
        public virtual Flight Flight { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
