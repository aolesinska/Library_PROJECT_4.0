using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class ReaderValidation : BasicValidation
    {
        public ValidationResult FirstNameValidation(string text)
        {
            var result = this.ValidateInput(text, "First Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
        public ValidationResult LastNameValidation(string text)
        {
            var result = this.ValidateInput(text, "Last Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
        public ValidationResult EmailValidation(string text)
        {
            var result = this.ValidateInput(text, "Email", 50, 15);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
        public ValidationResult PeselValidation(string text)
        {
            var result = this.ValidateInput(text, "PESEL", 11, 11);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
