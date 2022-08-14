using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.util
{
    public class IOHelper
    {

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

        public static void DisplayResults(SalaryDetails results)
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
                output += $"{deduction.friendlyName}: {(deduction.roundToNearestDollar ? Math.Round(deduction.deductionAmount, 0).ToString("C") : Math.Round(deduction.deductionAmount, 2).ToString("C"))}\n";
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