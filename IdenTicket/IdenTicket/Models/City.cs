using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Города
    /// </summary>
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

    }
}
