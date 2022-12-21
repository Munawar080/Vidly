using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Min18YearsIFAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // cast to customer model
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1) 
                    return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("BirthDate is required");

            // culculate the age
            // value prop accessable if birthdate prop in model is NULLABLE
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return age >= 18 ? ValidationResult.Success : new ValidationResult("Minimum age should be 18 years");
        }
    }
}