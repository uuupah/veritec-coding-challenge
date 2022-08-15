using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritechChallenge.src.model
{
    /// <summary>
    /// a tuple style struct designed to join the gross income and pay frequency to be calculated by 
    /// <see cref="util.SalaryDetails"/>.
    /// </summary>
    public struct PayrollDetails
    {
        decimal grossIncome {get;}
        PayFreq payFreq {get;}

        public PayrollDetails(decimal grossIncome, PayFreq payFreq) {
            if (grossIncome < 0) {
                throw new ArgumentException("Gross income must be a number equal to or greater than zero");
            }
            
            this.grossIncome = grossIncome;
            this.payFreq = payFreq;
        }
    }
}