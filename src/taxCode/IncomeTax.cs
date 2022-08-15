using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    /// <summary> 
    /// Represents the calculation required for Income Tax. Has one method, <see cref="TaxCode.GetDeduction(decimal)"/> which 
    /// returns a <see cref="model.DeductionData"/> object with the <see cref="TaxCode.friendlyName"/> of the particular tax code
    /// and a deduction amount depending on the entered <c>taxableIncome</c>. Intended for use with 
    /// <see cref="util.SalaryDetails"/> where multiple tax codes can be added to a list and deductions calculated automatically.
    /// </summary>
    public class IncomeTax : TaxCode
    {
        public new string friendlyName {get;}

        /// <summary>Instantiates a new <c>IncomeTax</c> object.</summary>
        public IncomeTax() {
            this.friendlyName = "Income Tax";
        }

        /// <summary>
        /// This method takes a decimal taxable income and returns the appropriate amount of income tax.
        /// </summary>
        /// <param name="taxableIncome">A positive or zero decimal representing a taxable income value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <c>taxableIncome</c> is less than zero.
        /// </exception>
        public override DeductionData GetDeduction(decimal taxableIncome)
        {
            if (taxableIncome < 0) {
                throw new ArgumentException("Taxable income must be a number equal to or greater than zero");
            }

            decimal deduction;
            taxableIncome = Math.Floor(taxableIncome);

            if (taxableIncome <= 18200) {
                deduction = 0;
            } else if (taxableIncome <= 37000) {
                deduction = (taxableIncome - 18200) * 0.19m;
            } else if (taxableIncome <= 87000) {
                deduction = 3572 + ((taxableIncome - 37000) * 0.325m);
            } else if (taxableIncome <= 180000) {
                deduction = 19822 + ((taxableIncome - 87000) * 0.1m);
            } else {
                deduction = 54232 + ((taxableIncome - 180000) * 0.47m);
            } 

            return new DeductionData(friendlyName, Math.Ceiling(deduction));
        }
    }
}