﻿namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class ReaderValidation : BasicValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult FirstNameValidation(string text)
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
        public ValidationResult LastNameValidation(string text)
        {
            var result = this.ValidateInput(text, "Last Name", 30, 3);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult EmailValidation(string text)
        {
            var result = this.ValidateInput(text, "Email", 50, 15);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ValidationResult PeselValidation(string text)
        {
            var result = this.ValidateInput(text, "PESEL", 11, 11);
            if (!result.IsValidate)
                return result;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
    }
}
