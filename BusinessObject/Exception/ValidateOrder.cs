using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Exception
{
    public class ValidateOrder
    {
        public static void CatchExceptionOrder(Order order)
        {
            var validationContext = new ValidationContext(order, null, null);
            var validationResults = new List<ValidationResult>();

            // Perform validation
            bool isValid = Validator.TryValidateObject(order, validationContext, validationResults, true);

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
