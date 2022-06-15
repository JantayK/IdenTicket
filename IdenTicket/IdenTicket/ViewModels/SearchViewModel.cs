using IdenTicket.Enums;
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
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public FlightType FlightType { get; set; }
    }
}
