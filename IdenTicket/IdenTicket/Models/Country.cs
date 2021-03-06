using IdenTicket.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Страны
    /// </summary>
    public class Country : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<AirLine> AirLines { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
