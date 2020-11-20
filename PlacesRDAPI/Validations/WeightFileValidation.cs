using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Validations
{
    public class WeightFileValidation : ValidationAttribute 
    {
        private readonly int maxWeightMB;

        public WeightFileValidation(int MaxWeightMB)
        {
            maxWeightMB = MaxWeightMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) { return ValidationResult.Success; }

            IFormFile formfile = value as IFormFile;

            if(formfile == null)
            {
                return ValidationResult.Success;
            }

            if(formfile.Length > maxWeightMB * 1024 * 1024)
            {
                return new ValidationResult($"File weight must be less than {maxWeightMB} MB");
            }

            return ValidationResult.Success;

        }
    }
}
