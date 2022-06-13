using IdenTicket.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Города
    /// </summary>
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
