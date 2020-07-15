using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Validation
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (!customer.BirthDate.HasValue)
                return new ValidationResult("Birthdate is required");

            var birthYear = customer.BirthDate.Value.Year;
            var checkYear = DateTime.Now.Year - birthYear;

            return checkYear >= 18
            ? ValidationResult.Success
            : new ValidationResult("You should be 18+ to go with this membership");
        }
    }
}