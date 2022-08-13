using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.util
{
    public class IOHelper
    {
        public static decimal? RequestGrossIncome()
        {
            Console.Write("Enter your salary package amount: ");
            decimal grossIncome = Convert.ToDecimal(Console.ReadLine());
            return grossIncome;
        }

        public static PayFreq? RequestPayFreq()
        {
            PayFreq payFreq;
            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            char input = Convert.ToChar(Console.ReadLine());
            switch (input)
            {
                case 'W':
                    payFreq = PayFreq.W;
                    break;
                case 'F':
                    payFreq = PayFreq.F;
                    break;
                case 'M':
                    payFreq = PayFreq.M;
                    break;
                default:
                    payFreq = PayFreq.W;
                    break;
            }

            return payFreq;
        }

        public static void DisplayCalculationNotification()
        {
            Console.WriteLine("\nCalculating salary details...\n");
        }

        // only leaving the input variable nullable while doing structuring work
        // TODO remove nullable
        public static void DisplayResults(ResultsData? results)
        {
            Console.WriteLine(@"Gross package: $65,000
Superannuation: $5,639.27

Taxable income: $59,360.73

Deductions:
Medicare Levy: $1,188.00
Budget Repair Levy: $0
Income Tax: $10,839.00

Net income: $47,333.73
Pay packet: $3,944.48 per month

Press any key to end...");
            Console.ReadKey(true);
        }
    }
}