using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    class AuthorValidation : BasicValidation
    {
        public ValidationResult FNameValidation(string text)
        {
            var result = this.ValidateInput(text, "First Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = null };
        }
        public ValidationResult LNameValidation(string text)
        {
            var result = this.ValidateInput(text, "Last Name", 30, 2);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = null };
        }
    }

}
