using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class PublisherValidation : BasicValidation
    {
        public ValidationResult PostcodeValidation(string text)
        {
            var result = this.ValidateInput(text, "Postcode", 6, 6);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
