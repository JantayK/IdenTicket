using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Модели Самолета
    /// </summary>
    public class AirplaneModel
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Model { get; set; }

        public virtual ICollection<FlightLeg> FlightLegs { get; set; }
    }
}
