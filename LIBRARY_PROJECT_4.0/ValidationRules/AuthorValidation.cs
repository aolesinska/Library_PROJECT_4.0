namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class AuthorValidation : BasicValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult FNameValidation(string text)
        {
            var result = this.ValidateInput(text, "First Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult LNameValidation(string text)
        {
            var result = this.ValidateInput(text, "Last Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }

}
