using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntAppSecond.Models
{
    public class BirthDateAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object Date, ValidationContext validationContext)
        {
            Student student = (Student)validationContext.ObjectInstance;

            DateTime start = DateTime.Today.AddYears(-5);
            DateTime end = DateTime.Today.AddYears(-2);

            if (student.DateOfBirth < start | student.DateOfBirth > end)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-BirthDate", GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return $"The Child must be aged between 3 and 5 years";
        }
    }
}
