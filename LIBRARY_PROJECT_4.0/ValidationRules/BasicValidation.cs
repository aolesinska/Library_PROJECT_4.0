using System;
using System.Text.RegularExpressions;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidationResult
    {
        public bool IsValidate { get; set; }
        public string ErrorMsg { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BasicValidation
    {
        protected ValidationResult ValidateInput(string text, string fieldName, int maxLenght, int minLenght)
        {
            if (String.IsNullOrWhiteSpace(text))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be empty" };

            if (text.Trim().Length > maxLenght)
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be longer than {maxLenght} chars" };

            if (text.Trim().Length < minLenght)
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} cannot be shorter than {minLenght} chars" };

            if (fieldName == "Email" && !text.Contains("@") || fieldName == "Email" && !text.Contains("."))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} has incorrect syntax. Please provide correct email" };

            if (fieldName == "PESEL" && Regex.IsMatch(text, "[a-zA-Z]"))
                return new ValidationResult { IsValidate = false, ErrorMsg = $"{fieldName} can contain only numbers" };

            if (fieldName == "Postcode" && text[2] != '-')
                return new ValidationResult { IsValidate = false, ErrorMsg = $"Invalid {fieldName}" };

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
