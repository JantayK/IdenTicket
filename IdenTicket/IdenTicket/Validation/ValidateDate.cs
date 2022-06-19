using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Validation
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object date, ValidationContext validationContext)
        {
            return ((DateTime?)date >= DateTime.Today && (DateTime?)date <= DateTime.Today.AddYears(5))
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
    }
}
