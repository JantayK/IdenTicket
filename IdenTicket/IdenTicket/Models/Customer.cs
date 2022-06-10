using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Клиента
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        [Required]
        public string PassportNumber { get; set; }
        public virtual Country Country { get; set; }

    }
}
