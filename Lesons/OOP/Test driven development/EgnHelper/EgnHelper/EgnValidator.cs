using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace EgnHelper
{
    public class EgnValidator : IEgnValidator
    {
        private int[] weightOfDigits = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        public bool IsValid(string egn)
        {
            //10numbers and !null
            //61 01 05 7509
            if (egn == null)
            {
                throw new ArgumentNullException(nameof(egn));
            }

            if (!Regex.IsMatch(egn, "[0-9]{10}"))
            {
                return false;
            }

            int yearPart = int.Parse(egn.Substring(0, 2));
            int monthPart = int.Parse(egn.Substring(2, 2));
            int dayPart = int.Parse(egn.Substring(4, 2));
            
            int month = 0;
            int year = yearPart;
            if (monthPart >= 21 && monthPart <= 32)
            {
                year += 1800;
                month = monthPart - 20;
                //+20 to month for this years
                //1800- 1899
            }
            else if (monthPart >= 41 && monthPart <= 52)
            {
                year += 2000;
                month = monthPart - 40;
                //+40 to month for this years
                //200-2099
            }
            else if (monthPart >= 1 && monthPart <= 22)
            {
                year += 1900;
                monthPart = month;
                //1900-1999
            }
            else
            {
                return false;
            }

            if (!DateTime.TryParseExact(
                $"{year}-{month}-{dayPart}",
                "yyyy-M-d",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _)) 
            {

            }

            //check sum last digit
            var checkSum = 0;
            for (int i = 0; i < 8; i++)
            {
                var digit = egn[i]-'0';
                checkSum += digit * weightOfDigits[i];
            }

            var lastDigit = checkSum % 11;
            if(lastDigit==10)
            {
                lastDigit = 0;
            }
            
            if(int.Parse(egn[9].ToString())!=lastDigit)
            {
                return false;
            }

            return true;
        }
    }
}
