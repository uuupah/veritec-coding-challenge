using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeritechChallenge.src.model;

namespace VeritechChallenge.src.taxCode
{
    public abstract class TaxCode
    {
        // TODO check if adding nullable is necessary
        public string? friendlyName {get;}
        public bool roundToNearestDollar {get;}

        public abstract DeductionData GetDeduction(decimal taxableIncome);
    }
}