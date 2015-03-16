using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP2CreditUnion
{
    //Class for calling validation
    //Static so does need to be instansiated
    //in DataModel class library so can be called throughout project
    public static class Validation
    {
        static Regex number = new Regex("[0-9]+");
        static Regex phoneNumber = new Regex("[0-9]{2,3}-[0-9]{6,7}");
        static Regex password = new Regex(@"^(?=.*\d).{4,}$");
        static Regex email = new Regex(@"^\S+@\S+$");
        static Regex text = new Regex("[A-Z ]+", RegexOptions.IgnoreCase);
        static Regex userName = new Regex("[A-Z0-9]{5,}", RegexOptions.IgnoreCase);
        static Regex currency = new Regex(@"\d+(\.\d{2})");
        static Match match;

        //methods will return true/false after checking against regex's
        public static bool IsTextFormat(string input)
        {
            match = text.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool IsPhoneNumberFormat(string input)
        {
            match = phoneNumber.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool IsPasswordFormat(string input)
        {
            match = password.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool IsEmailFormat(string input)
        {
            match = email.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool IsNumberFormat(string input)
        {
            match = number.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool IsUserNameFormat(string input)
        {
            match = userName.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool IsCurrencyFormat(string input)
        {
            match = currency.Match(input);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
