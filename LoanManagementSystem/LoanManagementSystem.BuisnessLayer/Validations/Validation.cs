using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LoanManagementSystem.BAL.Validations
{
    public class Validation
    {
        public static bool ValidatePassword(string input)
        {
            string pattern = "(?=.*[a-z])"
                      + "(?=.*[@#$%^&+=])"
                      + "^(?=.*[0-9])"
                      + "(?=\\S+$).{6,20}$";
            //string pattern = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\]){8,32}$";
            if (Regex.IsMatch(input, pattern))
                return true;
            else
                return false;
        }
        public static bool ValidateUsername(string input)
        {
            string pattern = "^[A-Za-z0-9]{3,10}$";
            if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                return true;
            else
                return false;
        }
        public static bool ValidateContactNumber(decimal input)
        {
            string number = Convert.ToString(input);
            string pattern = @"^[6789]\d{9}$";
            //string pattern = "^[0-9]{10}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(number))
                return true;
            else
                return false;
        }
        // Method to check the Email ID
        public static bool ValidateEmail(string input)
        {
            // This Pattern is use to verify the email 
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }
        //Customer Pan Validation
        public static bool ValidatePAN(string input)
        {
            string strRegex = "^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }
        public static bool ValidateAadhar(decimal input)
        {
            string number = Convert.ToString(input);
            //string pattern = @"^[6789]\d{9}$";
            string pattern = "^[0-9]{12}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(number))
                return true;
            else
                return false;
        }
    }
}
