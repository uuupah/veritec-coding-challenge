using System;
using VeritechChallenge.src.model;
using VeritechChallenge.src.util;

namespace VeritecChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal grossIncome = IOHelper.RequestGrossIncome();
            PayFreq payFreq = IOHelper.RequestPayFreq();

            SalaryDetails salaryDetails = new SalaryDetails(grossIncome, payFreq);

            IOHelper.DisplayResults(salaryDetails);
        }
    }
}