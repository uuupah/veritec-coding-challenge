using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritechChallenge.src.model
{
    public struct DeductionData
    {
        public string friendlyName {get;}
        public bool roundToNearestDollar {get;}
        public decimal deductionAmount {get;}

        public DeductionData(string friendlyName, bool roundToNearestDollar, decimal deductionAmount) {
            this.friendlyName = friendlyName;
            this.roundToNearestDollar = roundToNearestDollar;            
            this.deductionAmount = deductionAmount;
        }
    }
}