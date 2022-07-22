namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class AuthorValidation : BasicValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
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
