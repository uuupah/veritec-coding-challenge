using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritechChallenge.src.model
{
    public struct PayrollDetails
    {
        decimal grossIncome {get;}
        PayFreq payFreq {get;}

        public PayrollDetails(decimal grossIncome, PayFreq payFreq) {
            this.grossIncome = grossIncome;
            this.payFreq = payFreq;
        }
    }
}