using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entelect.ErrorHandling;

namespace Entelect.Encentivize.Sdk
{
    public class ValidationFailedError : LogicError
    {
        public ValidationFailedError(List<ValidationResult> results)
            :base(GetMessage(results))
        {
        }

        private static string GetMessage(IEnumerable<ValidationResult> results)
        {
            var sb = new StringBuilder();
            foreach (var validationResult in results)
            {
                sb.AppendLine(validationResult.ErrorMessage);
            }
            return sb.ToString();
        }
    }
}