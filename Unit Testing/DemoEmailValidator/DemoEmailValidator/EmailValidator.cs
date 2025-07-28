using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // Regex is used for regular expression operations

namespace EmailValidatorApp
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email) // Method to validate email addresses
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // ^ - start of string
            // [^@\s]+ - one or more characters that are not '@' or whitespace
            // $ - end of string
            // @ - at least one '@' character
            // Mobile no: @"^[6-9]\d{9}$"
            //Pin code: @"^\d{6}$"
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple regex pattern for email validation
            return Regex.IsMatch(email, pattern); // definded inside Regex package
        }
    }
}
