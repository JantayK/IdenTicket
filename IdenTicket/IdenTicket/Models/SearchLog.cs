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
        [Display(Name = "Дата поиска")]
        public DateTime SearchDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Аэропорт отбытия")]
        public string DepartureAirport { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Аэропорт прибытия")]
        public string DestinationAirport { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата отбытия")]
        public DateTime DepartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата возврата")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Тип рейса")]
        public FlightType FlightType { get; set; }

        [Display(Name = "Удалено?")]
        public bool IsDeleted { get; set; }

        public Customer Customer { get; set; }
    }
}
