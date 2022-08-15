using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    /// <summary> 
    /// Abstract class for defining a tax class. Has one method, <see cref="TaxCode.GetDeduction(decimal)"/> which is 
    /// returns a <see cref="model.DeductionData"/> object with the <see cref="TaxCode.friendlyName"/> of the particular tax code
    /// and a deduction amount depending on the entered <c>taxableIncome</c>. Intended for use with 
    /// <see cref="util.SalaryDetails"/> where multiple tax codes can be added to a list and deductions calculated automatically.
    /// </summary>
    public abstract class TaxCode
    {
        ///<value>A human readable version of the TaxCode's name for display purposes.</value>
        ///<example>"Budget Repair Levy" for class BudgetRepairLevy</example>
        public string? friendlyName {get;}

        /// <summary>
        /// This method takes a decimal taxable income and returns an appropriate deduction depending on the particular
        /// tax code. 
        /// </summary>
        /// <param name="taxableIncome">A positive or zero decimal representing a taxable income value</param>
        public abstract DeductionData GetDeduction(decimal taxableIncome);
    }
}