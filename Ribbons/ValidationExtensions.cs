using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ribbons;

public static class ValidationExtensions
{
    public static bool TryValidateObject(this object obj, out List<string> validationErrors)
    {
        List<ValidationResult> validationResults = [];

        bool isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults, true);

        validationErrors = validationResults.Select(x => x.ErrorMessage).ToList();

        return isValid;
    }
}