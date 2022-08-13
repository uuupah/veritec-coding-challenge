using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritechChallenge.src.model
{
    public class SalaryDetails
    {
        private const decimal superRate = 0.095m;

        // this assumes 365 days in a year
        private const decimal weeksInYear = 365 / 7m;

        public decimal grossIncome {get;}
        public PayFreq payFreq {get;}

        public SalaryDetails(decimal grossIncome, PayFreq payFreq) {
            this.grossIncome = grossIncome;
            this.payFreq = payFreq;
        }
        
        public decimal GetTaxableIncome() {
            return grossIncome / (superRate + 1);
        }

        public decimal GetSuperAnnuation() {
            return grossIncome - GetTaxableIncome();
        }

        public List<DeductionData> GetDeductions() {
            List<DeductionData> output = new List<DeductionData>();

            //TODO automate adding new deductions from strings 
            output.Add(new DeductionData("Medicare Levy", true, 1188.00m));
            output.Add(new DeductionData("Budget Repair Levy", true, 0m));
            output.Add(new DeductionData("Income Tax", true, 10839.00m));

            return output;
        }

        public decimal GetNetIncome() {
            // TODO check this actually works
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
    }
}