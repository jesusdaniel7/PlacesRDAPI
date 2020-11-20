using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Validations
{
    public class ContentTypeValidation : ValidationAttribute
    {
        private readonly string[] validTypes;

        public ContentTypeValidation(string[] ValidTypes )
        {
            validTypes = ValidTypes;
        }

        public ContentTypeValidation(ContentTypeGroup contentTypeGroup)
        {
            if(contentTypeGroup == ContentTypeGroup.Photo)
            {
                validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) { return ValidationResult.Success; }

            IFormFile formfile = value as IFormFile;

            if (formfile == null)
            {
                return ValidationResult.Success;
            }

            if (!validTypes.Contains(formfile.ContentType))
            {
                return new ValidationResult($"The file type must be  {string.Join(", ", validTypes)}");
            }

            return ValidationResult.Success;

        }

    }
}
