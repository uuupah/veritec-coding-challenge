using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.taxCode;

namespace VeritechChallenge.src.model
{
    /// <summary>
    /// This class performs income and taxation calculations based on the input gross income and pay frequency, as well as the
    /// added taxcodes in the class constructor. 
    /// </summary>
    public class SalaryCalcs
    {
        private const decimal _superRate = 0.095m;

        // this assumes 365 days in a year
        private const decimal _weeksInYear = 365 / 7m;

        public decimal grossIncome {get;}
        public PayFreq payFreq {get;}
        public List<TaxCode> TaxCodes {get;}

        /// <exception cref="ArgumentException">
        /// Thrown when grossIncome is less than zero
        /// </exception>
        public SalaryCalcs(decimal grossIncome, PayFreq payFreq) {
            if (grossIncome < 0) {
                throw new ArgumentException("Gross income must be a number equal to or greater than zero");
            }

            this.grossIncome = grossIncome;
            this.payFreq = payFreq;
            TaxCodes = new List<TaxCode>();

            TaxCodes.Add(new MedicareLevy());
            TaxCodes.Add(new BudgetRepairLevy());
            TaxCodes.Add(new IncomeTax());
        }
        
        /// <returns>
        /// Returns the taxable income based on the set superannuation rate.
        /// </returns>
        public decimal GetTaxableIncome() {
            return grossIncome / (_superRate + 1);
        }

        /// <returns>
        /// Returns the superannuation contribution based on the set superannuation rate.
        /// </returns>
        public decimal GetSuperAnnuation() {
            return grossIncome - GetTaxableIncome();
        }

        /// <returns>
        /// Returns a list of DeductionData objects representing the tax deductions applied to the given gross income.
        /// </returns>
        public List<DeductionData> GetDeductions() {
            List<DeductionData> output = new List<DeductionData>();

            foreach(TaxCode taxCode in TaxCodes) {
                output.Add(taxCode.GetDeduction(GetTaxableIncome()));
            }

            return output;
        }

        /// <returns>
        /// Returns the net income (gross income with super contribution and tax deductions subtracted).
        /// </returns>
        public decimal GetNetIncome() {
            decimal totalDeductions = GetDeductions().Sum(deduction => deduction.deductionAmount);
            return GetTaxableIncome() - totalDeductions;
        }

        /// <returns>
        /// Returns the pay packet per the given pay frequency.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">
        /// Thrown when payFreq does not match a recognised value of PayFreq
        /// </exception>
        public decimal GetPayPacket() {
            switch (payFreq)
            {
                case PayFreq.W:
                    return GetNetIncome() / _weeksInYear;
                case PayFreq.F:
                    return GetNetIncome() / (_weeksInYear / 2);
                case PayFreq.M:
                    return GetNetIncome() / 12;
                default:
                    throw new InvalidEnumArgumentException("Invalid pay frequency enumeration value used");
            }
        }

        /// <returns>
        /// Returns a friendly pay frequency string per the given pay frequency.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">
        /// Thrown when payFreq does not match a recognised value of PayFreq
        /// </exception>
        public string GetFriendlyPayFreq() {
            switch (payFreq)
            {
                case PayFreq.W:
                    return "week";
                case PayFreq.F:
                    return "fortnight";
                case PayFreq.M:
                    return "month";
                default:
                    throw new InvalidEnumArgumentException("Invalid pay frequency enumeration value used");
            }
        }
    }
}