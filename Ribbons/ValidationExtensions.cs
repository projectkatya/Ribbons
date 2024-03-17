using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ribbons
{
    public static class ValidationExtensions
    {
        public static bool TryValidateObject(this object obj, out Dictionary<string, string> validationErrors)
        {
            List<ValidationResult> validationResults = [];

            validationErrors = [];
            
            bool isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                validationErrors.Add(validationResult.MemberNames.FirstOrDefault(), validationResult.ErrorMessage);
            }

            return isValid;
        }
    }
}