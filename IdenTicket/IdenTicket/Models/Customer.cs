using IdenTicket.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Клиента
    /// </summary>
    public class Customer : User
    {
        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(150)]
        public string PassportNumber { get; set; }

        public virtual Country Country { get; set; }
    }
}
