using System;
using System.Text.RegularExpressions;

namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    /// <summary>
    /// Model to a validation result
    /// </summary>
    public class ValidationResult
    {
        public bool IsValidate { get; set; }
        public string ErrorMsg { get; set; }
    }

    
    public class BasicValidation
    {
        /// <summary>
        /// Function to validate input by params
        /// </summary>
        /// <param name="text">Text need to be validate</param>
        /// <param name="fieldName">Field we want to validate</param>
        /// <param name="maxLenght">Max length of input</param>
        /// <param name="minLenght">Min length of input</param>
        /// <returns>Validate result based on model></returns>
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
