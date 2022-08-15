using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.util
{
    /// <summary>
    /// A helper class designed to encapsulate console input / output commands. 
    /// </summary>
    public class IOHelper
    {

        /// <summary>
        /// This method sends a message to the console requesting a gross salary package, then waits for the user to type in a 
        /// response to the console. Refuses non-numeric, null and negative inputs, prompting the user until a valid input is
        /// entered. Validation completed by <see cref="ValidationHelper.ValidateGrossIncome(string?, out decimal)"/>
        /// </summary>
        /// <returns>
        /// A decimal representing the valid gross income value entered by the user.
        /// </returns>
        public static decimal RequestGrossIncome()
        {
            Console.Write("Enter your salary package amount: ");

            decimal grossIncome;
            while (!ValidationHelper.ValidateGrossIncome(Console.ReadLine(), out grossIncome))
            {
                Console.Write("Invalid input. Enter your salary package amount: ");
            }

            return grossIncome;
        }

        /// <summary>
        /// This method sends a message to the console requesting a single character representing their pay frequency, then waits 
        /// for the user to type in a response to the console. Refuses non char and null inputs, prompting the user until a valid 
        /// input is entered. Validation completed by <see cref="ValidationHelper.ValidatePayFreq(string?, out PayFreq)"/>
        /// </summary>
        /// <returns>
        /// A <c>PayFreq</c> object representing the pay frequency specified by the user.
        /// </returns>
        public static PayFreq RequestPayFreq()
        {
            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");

            PayFreq payFreq;
            while (!ValidationHelper.ValidatePayFreq(Console.ReadLine(), out payFreq))
            {
                Console.Write("Invalid input. Enter your pay frequency: ");
            }

            return payFreq;
        }

        /// <summary>
        /// Acts as a kind of helper function to display the results from a <see cref="SalaryCalcs"/> object to the user. 
        /// </summary>
        /// <param name="results">A SalaryDetails object</param>
        public static void DisplayResults(SalaryCalcs results)
        {
            Console.WriteLine("\nCalculating salary details...\n");

            string output = "";

            output += $"Gross package: {results.grossIncome.ToString("C")}\n";
            output += $"Superannuation: {results.GetSuperAnnuation().ToString("C")}\n";
            output += "\n";
            output += $"Taxable Income: {results.GetTaxableIncome().ToString("C")}\n";
            output += "\n";
            output += "Deductions:\n";

            foreach (DeductionData deduction in results.GetDeductions())
            {
                output += $"{deduction.friendlyName}: {(deduction.deductionAmount.ToString("C"))}\n";
            }

            output += "\n";
            output += $"Net Income: {results.GetNetIncome().ToString("C")}\n";
            output += $"Pay Packet: {results.GetPayPacket().ToString("C")} per {results.GetFriendlyPayFreq()}\n";
            output += "\n";
            output += "Press any key to end...";

            Console.WriteLine(output);
            Console.ReadKey(true);
        }
    }
}