namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class PublisherValidation : BasicValidation
    {
        /// <summary>
        /// Function to validate input during adding a new publisher
        /// </summary>
        /// <param name="text">Publisher's postcode</param>
        /// <returns>Validation message and boolean value</returns>
        public ValidationResult Validation(string text)
        {
            var result = this.ValidateInput(text, "Postcode", 6, 6);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
