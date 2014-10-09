using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entelect.Encentivize.Sdk
{
    public abstract class BaseInput
    {
        public virtual void Validate()
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), results, true);
            if (results.Any())
            {
                var error = new ValidationFailedError(results);
                error.Throw();
            }
        }
    }
}