using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class IncomeTax : TaxCode
    {
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            return new DeductionData("Income Tax", true, 10839.00m);
        }
    }
}