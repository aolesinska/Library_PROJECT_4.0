namespace LIBRARY_PROJECT_4._0.ValidationRules
{
    public class ReaderValidation : BasicValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="pesel"></param>
        /// <returns></returns>
        public ValidationResult Validation (string firstName, string lastName, string email, string pesel)
        {
            var firstNresult = this.ValidateInput(firstName, "First Name", 30, 3);
            if (!firstNresult.IsValidate)
                return firstNresult;

            var lastNresult = this.ValidateInput(lastName, "Last Name", 30, 3);
            if (!lastNresult.IsValidate)
                return lastNresult;

            var emailresult = this.ValidateInput(email, "Email", 50, 15);
            if (!emailresult.IsValidate)
                return emailresult;

            var peselresult = this.ValidateInput(pesel, "PESEL", 11, 11);
            if (!peselresult.IsValidate)
                return peselresult;

            return new ValidationResult { IsValidate = true, ErrorMsg = "" };
        }
        
    }
}
