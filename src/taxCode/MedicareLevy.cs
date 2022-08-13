using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public class MedicareLevy : TaxCode
    {
        public new string friendlyName {get;}
        public new bool roundToNearestDollar {get;}

        public MedicareLevy() {
            this.friendlyName = "Medicare Levy";
            this.roundToNearestDollar = true;
        }
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            decimal deduction;
            taxableIncome = Math.Floor(taxableIncome);

            if (taxableIncome >= 0 && taxableIncome < 21336) {
                deduction = 0;
            } else if (taxableIncome >= 21336 && taxableIncome < 26669) {
                deduction = Math.Ceiling((taxableIncome - 21335) * 0.1m);
            } else if (taxableIncome >= 26669) {
                deduction = Math.Ceiling((taxableIncome * 0.02m));
            } else {
                throw new ArgumentException("Taxable income must be a number equal to or greater than zero");
            }

            return new DeductionData(friendlyName, roundToNearestDollar, deduction);
        }
    }
}