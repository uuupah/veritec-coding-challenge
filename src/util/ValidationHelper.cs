using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.util
{
    /// <summary>
    /// Provides specific validation for data types relevant to the salary calculation. Methods follow the 
    /// <see cref="TryParse(string input, var out output)"/> style, returning a boolean representing on the validity of the input
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// Converts the string representation of a number to its System.Decimal equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <c>input</c> represented a positive integer or decimal, otherwise <c>false</c>.
        /// </returns>
        public static bool ValidateGrossIncome(string? input, out decimal output)
        {
            if (input is null)
            {
                output = 0m;
                return false;
            }

            bool valid;

            valid = decimal.TryParse(input, out output);

            // this could potentially be done by looking for a hyphen at the start 
            // of the input string
            if (valid && output >= 0) {
                return true;
            }

            return false;       
        }

        /// <summary>
        /// Converts the string representation of a number to its System.Decimal equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <c>input</c> represents one of the possible PayFreq values, otherwise 
        /// <c>false</c>.
        /// </returns>
        public static bool ValidatePayFreq(string? input, out PayFreq output)
        {
            // catch null and non-char, non-letter inputs
            if (input is null || !Regex.IsMatch(input, @"^[a-zA-Z]$"))
            {
                output = new PayFreq();
                return false;
            }

            return PayFreq.TryParse(input.ToUpper(), out output);
        }
    }
}