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
            PayFreq payFreq;

            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");

            while (!ValidationHelper.ValidatePayFreq(Console.ReadLine(), out payFreq))
            {
                Console.Write("Invalid input. Enter your pay frequency: ");
            }

            return payFreq;
        }

        public static void DisplayCalculationNotification()
        {
            Console.WriteLine("\nCalculating salary details...\n");
        }

        public static void DisplayResults(SalaryDetails results)
        {

            Console.WriteLine($"Gross package: {results.grossIncome.ToString("C")}");
            Console.WriteLine($"Superannuation: {results.GetSuperAnnuation().ToString("C")}");
            Console.WriteLine("");
            Console.WriteLine($"Taxable Income: {results.GetTaxableIncome().ToString("C")}");
            Console.WriteLine("");
            Console.WriteLine("Deductions:");

            foreach (DeductionData deduction in results.GetDeductions())
            {
                Console.WriteLine($"{deduction.friendlyName}: {(deduction.roundToNearestDollar ? Math.Round(deduction.deductionAmount, 0).ToString("C") : Math.Round(deduction.deductionAmount, 2).ToString("C"))}");
            }

            Console.WriteLine("");
            Console.WriteLine($"Net Income: {results.GetNetIncome().ToString("C")}");
            Console.WriteLine($"Pay Packet: {results.GetPayPacket().ToString("C")}");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end...");

            Console.ReadKey(true);
        }
    }
}