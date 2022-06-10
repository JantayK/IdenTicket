using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Аэропорта
    /// </summary>
    public class Airport
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string IATA { get; set; }


    }
}
