using System;
using VeritechChallenge.src.util;

namespace VeritecChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOHelper.RequestGrossIncome();
            IOHelper.RequestPayFreq();

            IOHelper.DisplayCalculationNotification();

            IOHelper.DisplayResults(null);
        }
    }
}