using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class BudgetRepairLevy : TaxCode
    {
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            return new DeductionData("Budget Repair Levy", true, 0m);
        }
    }
}