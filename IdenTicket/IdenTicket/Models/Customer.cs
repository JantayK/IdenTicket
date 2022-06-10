using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string PassportNumber { get; set; }

    }
}
