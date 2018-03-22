using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProject.RegexValidation.Controller
{
    public class ValidationController
    {
        public static bool OnlyNumbers(string _Input)
        {
            return Regex.IsMatch(_Input.Replace(" ", ""), @"^[0-9]+$");
        }

        public static bool IsValidPassword(string _Input)
        {
            // ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$ No special character
            return Regex.IsMatch(_Input, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
        }

        public static int ParseInt(string _Input)
        {
            try
            {
                return int.Parse(Regex.Match(_Input, @"\d+").Value);
            }
            catch
            {
                return -1;
            }

        }
    }
}
