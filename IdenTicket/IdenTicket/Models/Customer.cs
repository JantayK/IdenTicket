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
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Patronymic { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        [Required]
        public string PassportNumber { get; set; }

    }
}
