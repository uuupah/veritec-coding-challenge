using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public abstract class TaxCode
    {
        public abstract DeductionData GetDeduction(decimal taxableIncome);
    }
}