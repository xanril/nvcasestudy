using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Helpers
{
    class ValidationHelper
    {
        public static ValidationHelperResult ValidateProperty<T>(T target, string propertyName, object value) where T : class
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(target, null, null) { MemberName = propertyName };
            Validator.TryValidateProperty(value, validationContext, validationResults);

            return new ValidationHelperResult(validationResults);
        }

        public static bool IsPastDate(DateTime dateToCheck)
        {
            if (dateToCheck >= DateTime.Today)
                return false;

            return true;
        }

        public static bool IsFutureDate(DateTime dateToCheck)
        {
            if (dateToCheck <= DateTime.Today)
                return false;

            return true;
        }

        public static bool IsFirstCharacterLetter(string textToCheck)
        {
            if (string.IsNullOrEmpty(textToCheck))
                return false;

            string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (charset.Contains(textToCheck.Substring(0, 1)))
                return true;

            return false;
        }
    }

    public class ValidationHelperResult
    {
        public IEnumerable<ValidationResult> Results { get; private set; }
        public bool HasError
        {
            get { return Results.Count<ValidationResult>() > 0; }
        }

        public ValidationHelperResult(IEnumerable<ValidationResult> results = null)
        {
            Results = results ?? new List<ValidationResult>();
        }

        public string GetErrorMessages()
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach(ValidationResult result in Results)
            {
                strBuilder.AppendLine(result.ErrorMessage);
            }

            return strBuilder.ToString();
        }
    }
}
