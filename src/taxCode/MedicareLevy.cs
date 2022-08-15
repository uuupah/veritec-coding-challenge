using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{    
    /// <summary> 
    /// Represents the calculation required for the Medicare Levy. Has one method, 
    /// <see cref="TaxCode.GetDeduction(decimal)"/> which returns a <see cref="model.DeductionData"/> object with the 
    /// <see cref="TaxCode.friendlyName"/> of the particular tax code and a deduction amount depending on the entered 
    /// <c>taxableIncome</c>. Intended for use with <see cref="util.SalaryDetails"/> where multiple tax codes can be added to a 
    /// list and deductions calculated automatically.
    /// </summary>
    public class MedicareLevy : TaxCode
    {
        public new string friendlyName {get;}

        /// <summary>Instantiates a new <c>MedicareLevy</c> object.</summary>
        public MedicareLevy() {
            this.friendlyName = "Medicare Levy";
        }

        /// <summary>
        /// This method takes a decimal taxable income and returns the appropriate medicare levy.
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

            if (taxableIncome <= 21335) {
                deduction = 0;
            } else if (taxableIncome <= 26668) {
                deduction = (taxableIncome - 21335) * 0.1m;
            } else {
                deduction = (taxableIncome * 0.02m);
            } 

            return new DeductionData(friendlyName, Math.Ceiling(deduction));
        }
    }
}