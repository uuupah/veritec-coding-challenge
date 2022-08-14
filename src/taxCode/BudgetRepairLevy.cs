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
            if (taxableIncome < 0) {
                throw new ArgumentException("Taxable income must be a number equal to or greater than zero");
            }

            decimal deduction;
            taxableIncome = Math.Floor(taxableIncome);

            if (taxableIncome <= 180000) {
                deduction = 0;
            } else {
                deduction = Math.Ceiling(((taxableIncome - 180000) * 0.02m));
            } 

            return new DeductionData(friendlyName, roundToNearestDollar, deduction);
        }
    }
}