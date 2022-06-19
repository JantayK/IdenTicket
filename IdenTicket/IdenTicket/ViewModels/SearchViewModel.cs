using IdenTicket.Enums;
using IdenTicket.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.ViewModels
{
    /// <summary>
    /// Вью Модель начальной страницы
    /// </summary>
    public class SearchViewModel
    {
        [Required(ErrorMessage ="Это поле не может быть пустым")]
        [StringLength(50)]
        [Display(Name = "Аэропорт отбытия")]
        public string DepartureAirport { get; set; }
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [StringLength(50)]
        [Display(Name = "Аэропорт прибытия")]
        public string DestinationAirport { get; set; }

        [DataType(DataType.Date)]
        [ValidateDate(ErrorMessage = "Некорректная дата отбытия")]
        [Display(Name = "Дата отбытия")]
        public DateTime DepartDate { get; set; }

        [DataType(DataType.Date)]
        [ValidateDate(ErrorMessage = "Некорректная дата отбытия")]
        [Display(Name = "Дата возврата")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Тип рейса")]
        public FlightType FlightType { get; set; }
    }
}
