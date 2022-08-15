using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.taxCode;

namespace VeritechChallenge.src.model
{
    public class SalaryDetails
    {
        private const decimal superRate = 0.095m;

        // this assumes 365 days in a year
        private const decimal weeksInYear = 365 / 7m;

        public decimal grossIncome {get;}
        public PayFreq payFreq {get;}
        public List<TaxCode> TaxCodes {get;}

        public SalaryDetails(decimal grossIncome, PayFreq payFreq) {
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
        
        public decimal GetTaxableIncome() {
            return grossIncome / (superRate + 1);
        }

        public decimal GetSuperAnnuation() {
            return grossIncome - GetTaxableIncome();
        }

        public List<DeductionData> GetDeductions() {
            List<DeductionData> output = new List<DeductionData>();

            foreach(TaxCode taxCode in TaxCodes) {
                output.Add(taxCode.GetDeduction(GetTaxableIncome()));
            }

            return output;
        }

        public decimal GetNetIncome() {
            decimal totalDeductions = GetDeductions().Sum(deduction => deduction.deductionAmount);
            return GetTaxableIncome() - totalDeductions;
        }

        public decimal GetPayPacket() {
            switch (payFreq)
            {
                case PayFreq.W:
                    return GetNetIncome() / weeksInYear;
                case PayFreq.F:
                    return GetNetIncome() / (weeksInYear / 2);
                case PayFreq.M:
                    return GetNetIncome() / 12;
                default:
                    // the code should never reach this point
                    return GetNetIncome() / 12;
            }
        }

        // this is a bad solution but it will work for now
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
                    // the code should never reach this point
                    return "month";
            }
        }
    }
}