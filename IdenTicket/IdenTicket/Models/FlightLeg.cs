using IdenTicket.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Этапа Рейса
    /// </summary>
    public class FlightLeg
    {
        public int FlightId { get; set; }
        public Direction Direction { get; set; }
        public int LegNumber { get; set; }
        public int AirLineId { get; set; }
        public int AirplaneModelId { get; set; }
        public int DepartAirportId { get; set; }
        public int ArriveAirportId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArriveDate { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual AirLine AirLine { get; set; }
        public virtual AirplaneModel AirplaneModel { get; set; }
        public virtual Airport ArriveAirport { get; set; }
        public virtual Airport DepartAirport { get; set; }
    }
}
