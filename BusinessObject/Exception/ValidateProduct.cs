using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Exception
{
    public class ValidateProduct
    {
        public static void CatchExceptionProduct(Product product)
        {
            var validationContext = new ValidationContext(product, null, null);
            var validationResults = new List<ValidationResult>();

            // Perform validation
            bool isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            if (!isValid)
            {
                // Collect all validation errors
                var errorMessages = validationResults
                    .Select(vr => vr.ErrorMessage)
                    .ToList();

                // Join all error messages into a single string
                string allErrors = string.Join(Environment.NewLine, errorMessages);

                // Throw a single exception with all errors
                throw new ValidationException($"Validation failed: {Environment.NewLine}{allErrors}");
            }
        }
    }
}
