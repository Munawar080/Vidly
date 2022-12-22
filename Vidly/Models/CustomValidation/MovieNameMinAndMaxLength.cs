using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models.CustomValidation
{
    public class MovieNameMinAndMaxLength : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // first get the movie class
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.Name.Length > 0 || movie.Name.Length <= 20) return ValidationResult.Success;

            if (movie.Name == null) return new ValidationResult("Name is required");

           return movie.Name.Length > 20 || movie.Name.Length == 0
                ? new ValidationResult("Characters should be greater than 0 and less than or equal to 20")
                : ValidationResult.Success;
        }
    }
}