using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyPrototype.Models
{
    public class AgeRestrictionCustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypesId == 1)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of Birth field is required");

            var ageDifference = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            return (ageDifference >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Must be more than 18 years to be a member");

        }
    }
}