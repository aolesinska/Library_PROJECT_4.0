namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class PublisherValidation : BasicValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult PostcodeValidation(string text)
        {
            var result = this.ValidateInput(text, "Postcode", 6, 6);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
