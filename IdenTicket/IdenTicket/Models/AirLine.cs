using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Авиакомпании
    /// </summary>
    public class AirLine
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
    }
}
