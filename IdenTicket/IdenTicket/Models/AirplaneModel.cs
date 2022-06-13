using IdenTicket.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Модели Самолета
    /// </summary>
    public class AirplaneModel : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Model { get; set; }

        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
    }
}
