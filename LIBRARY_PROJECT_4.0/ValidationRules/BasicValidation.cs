using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class ValidationResult
    {
        public bool IsValidate { get; set; }
        public string ErrorMsg { get; set; }
    }
    public class BasicValidation
    {
        protected ValidationResult ValidateInput(string text, string fieldName, int maxLenght, int minLenght)
        {
            if (String.IsNullOrWhiteSpace(text))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be empty"};

            if (text.Trim().Length > maxLenght)
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be longer than {maxLenght} chars"};

            if (text.Trim().Length < minLenght)
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be shorter than {minLenght} chars"};
                        
            if (fieldName == "Email" && !text.Contains("@") && !text.Contains("."))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} has incorrect syntax. Please provide correct email"};

            if (fieldName == "PESEL" && text.Length != 11)
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} must contain exacly 11 numbers" };

            if (fieldName == "PESEL" && !Regex.IsMatch(text, "[a-zA-Z]"))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} can contain only numbers" };

            if (fieldName == "Postcode" && text.Length != 6 && text[2] != '-')
                return new ValidationResult { IsValidate = false, ErrorMsg = $"Invalid {fieldName}" };

            return new ValidationResult { IsValidate = true, ErrorMsg = null};
        }
    }
}
