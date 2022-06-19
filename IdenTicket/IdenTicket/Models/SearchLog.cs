using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdenTicket.Enums;

namespace IdenTicket.Models
{
    /// <summary>
    /// Модель истории поиска пользователя
    /// </summary>
    public class SearchLog
    {
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }
        public DateTime SearchDate { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartureAirport { get; set; }

        [Required]
        [StringLength(50)]
        public string DestinationAirport { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        public FlightType FlightType { get; set; }

        public Customer Customer { get; set; }
    }
}
