using IdenTicket.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Аэропорта
    /// </summary>
    public class Airport : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string IATA { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
    }
}
