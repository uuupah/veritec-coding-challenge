using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class IncomeTax : TaxCode
    {
        public new string friendlyName {get;}
        public new bool roundToNearestDollar {get;}

        public IncomeTax() {
            this.friendlyName = "Income Tax";
            this.roundToNearestDollar = true;
        }

        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            decimal deduction;
            taxableIncome = Math.Floor(taxableIncome);

            if (taxableIncome >= 0 && taxableIncome < 18201) {
                deduction = 0;
            } else if (taxableIncome >= 18201 && taxableIncome < 37001) {
                deduction = Math.Ceiling((taxableIncome - 18200) * 0.19m);
            } else if (taxableIncome >= 37001 && taxableIncome < 87001) {
                deduction = Math.Ceiling(3572 + ((taxableIncome - 37000) * 0.325m));
            } else if (taxableIncome >= 87001 && taxableIncome < 180001) {
                deduction = Math.Ceiling(19822 + ((taxableIncome - 87000) * 0.1m));
            } else if (taxableIncome >= 180001) {
                deduction = Math.Ceiling(54232 + ((taxableIncome - 180000) * 0.47m));
            } else {
                throw new ArgumentException("Taxable income must be a number equal to or greater than zero");
            }

            return new DeductionData(friendlyName, roundToNearestDollar, deduction);
        }
    }
}