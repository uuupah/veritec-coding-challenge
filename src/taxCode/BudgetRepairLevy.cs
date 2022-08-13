using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class BudgetRepairLevy : TaxCode
    {
        public new string friendlyName {get;}
        public new bool roundToNearestDollar {get;}

        public BudgetRepairLevy() {
            this.friendlyName = "Budget Repair Levy";
            this.roundToNearestDollar = true;
        }
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            decimal deduction;
            taxableIncome = Math.Floor(taxableIncome);

            if (taxableIncome >= 0 && taxableIncome < 180001) {
                deduction = 0;
            } else if (taxableIncome >= 180001) {
                deduction = Math.Ceiling(((taxableIncome - 180000) * 0.02m));
            } else {
                throw new ArgumentException("Taxable income must be a number equal to or greater than zero");
            }

            return new DeductionData(friendlyName, roundToNearestDollar, deduction);
        }
    }
}