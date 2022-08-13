using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class MedicareLevy : TaxCode
    {
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            return new DeductionData("Medicare Levy", true, 1188.00m);
        }
    }
}