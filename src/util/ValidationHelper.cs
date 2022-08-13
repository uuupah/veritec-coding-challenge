using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.util
{
    public class ValidationHelper
    {
        public static bool ValidateGrossIncome(string ?input, out decimal output) {
            return decimal.TryParse(input, out output);
        }

        public static bool ValidatePayFreq(string ?input, out PayFreq output) {
            // catch null and non-char, non-letter inputs
            if (input is null || !Regex.IsMatch(input, @"^[a-zA-Z]$")) {
                output = new PayFreq();
                return false;
            }

            return PayFreq.TryParse(input.ToUpper(), out output);
        }
    }
}