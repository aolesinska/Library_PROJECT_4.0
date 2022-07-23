namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class AuthorValidation : BasicValidation
    {
        /// <summary>
        /// Function to validate input during adding a new autor
        /// </summary>
        /// <param name="firstName">Autor's first name</param>
        /// <param name="lastName">Autor's last name</param>
        /// <returns>Validation message and bool value</returns>
        public ValidationResult Validation(string firstName, string lastName)
        {
            var firstNresult = this.ValidateInput(firstName, "First Name", 30, 3);
            if (!firstNresult.IsValidate)
                return firstNresult;
            var lastNresult = this.ValidateInput(lastName, "Last Name", 30, 3);
            if (!lastNresult.IsValidate)
                return lastNresult;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
        
    }

}
