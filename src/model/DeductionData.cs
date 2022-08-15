using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeritechChallenge.src.model
{
    /// <summary>
    /// a tuple style struct designed to join the results of a tax code deduction and the name in one object.
    /// </summary>
    public struct DeductionData
    {
        public string friendlyName {get;}
        public decimal deductionAmount {get;}

        public DeductionData(string friendlyName, decimal deductionAmount) {
            this.friendlyName = friendlyName;        
            this.deductionAmount = deductionAmount;
        }
    }
}