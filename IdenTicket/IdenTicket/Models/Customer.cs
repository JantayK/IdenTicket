using IdenTicket.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdenTicket.Models
{
    /// <summary>
    /// Класс Клиента
    /// </summary>
    public class Customer : IdentityUser
    {
        /// <summary>
        /// Полное имя клиента
        /// </summary>
        public string GetFullName()
        {
            return string.Join(' ', LastName, FirstName[0] + ".", !string.IsNullOrWhiteSpace(Patronymic) ? Patronymic[0] + "." : null);
        }

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
        public virtual ICollection<SearchLog> SearchLogs { get; set; }
    }
}
